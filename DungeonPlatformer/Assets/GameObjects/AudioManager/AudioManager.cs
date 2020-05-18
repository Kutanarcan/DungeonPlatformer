using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{
    namespace Audio
    {
        public class AudioManager : MonoBehaviour
        {
            public static AudioManager Instance { get; private set; }

            #region ClassAndEnumDecleration
            [System.Serializable]
            public class AudioObject
            {
                public MyAudioType type;
                public AudioClip clip;
            }

            [System.Serializable]
            public class AudioTrack
            {
                public AudioSource source;
                public AudioObject[] audios;
            }

            private class AudioJob
            {
                public AudioAction action;
                public MyAudioType type;
                public bool fade;
                public float delay;

                public AudioJob(AudioAction action, MyAudioType type, bool fade, float delay)
                {
                    this.action = action;
                    this.type = type;
                    this.fade = fade;
                    this.delay = delay;
                }
            }

            private enum AudioAction
            {
                START,
                STOP,
                RESTART
            }

            #endregion

            public bool debug;
            public AudioTrack[] tracks;// Index 0: Music  ,  Index 1: SFX

            private Hashtable audioTable;
            private Hashtable jobTable;
            private float musicVolumeLevel = 1f;

            private void Awake()
            {
                if (Instance)
                {
                    Destroy(gameObject);
                    return;
                }

                Instance = this;
                DontDestroyOnLoad(gameObject);

                Configure();
            }

            private void OnDisable()
            {
                Dispose();
            }

            public void SetMusicVolumeLevel(float volume)
            {
                tracks[0].source.volume = volume;
                musicVolumeLevel = volume;
            }

            public void SetSFXVolumeLevel(float volume)
            {
                tracks[1].source.volume = volume;
            }

            public void Play(MyAudioType type, bool fade = false, float delay = 0.0f)
            {
                AddJob(new AudioJob(AudioAction.START, type, fade, delay));
            }

            public void Stop(MyAudioType type, bool fade = false, float delay = 0.0f)
            {
                AddJob(new AudioJob(AudioAction.STOP, type, fade, delay));
            }

            public void Restart(MyAudioType type, bool fade = false, float delay = 0.0f)
            {
                AddJob(new AudioJob(AudioAction.RESTART, type, fade, delay));
            }

            public void PlaySoundOnPool(string prefabName, Vector3 position, Quaternion rotation, float returnPoolDuration = 3f)
            {
                GameObject soundPrefab = ObjectPooler.Instance.SpawnPoolObject(prefabName, position, rotation);
                soundPrefab.GetComponent<AudioSource>().volume = tracks[1].source.volume;
                ObjectPooler.Instance.ReturnToPool(soundPrefab.name, soundPrefab, returnPoolDuration);
            }

            private void Configure()
            {
                audioTable = new Hashtable();
                jobTable = new Hashtable();
                GenerateAudioTable();
            }

            private void Dispose()
            {
                if (jobTable != null)
                {
                    foreach (DictionaryEntry entry in jobTable)
                    {
                        IEnumerator jobCoroutine = (IEnumerator)entry.Value;
                        if (jobCoroutine != null)
                            StopCoroutine(jobCoroutine);
                    }
                }
            }

            private void AddJob(AudioJob newJob)
            {
                RemoveConflictJobs(newJob.type);

                IEnumerator jobRunnerCoroutine = RunAudioJob(newJob);
                jobTable.Add(newJob.type, jobRunnerCoroutine);
                StartCoroutine(jobRunnerCoroutine);

                Log($"Starting job on [{newJob.type}] with operation {newJob.action}");
            }

            private void RemoveJob(MyAudioType audioType)
            {
                if (!jobTable.ContainsKey(audioType))
                {
                    LogWarning($"You are trying to stop a job {audioType} that is not running");
                }

                IEnumerator runningJobCoroutine = (IEnumerator)jobTable[audioType];
                StopCoroutine(runningJobCoroutine);

                jobTable.Remove(audioType);
            }

            IEnumerator RunAudioJob(AudioJob currentJob)
            {
                yield return new WaitForSeconds(currentJob.delay);

                AudioTrack currentTrack = (AudioTrack)audioTable[currentJob.type];
                currentTrack.source.clip = GetAudioClipFromAudioTrack(currentJob.type, currentTrack);

                switch (currentJob.action)
                {
                    case AudioAction.START:
                        currentTrack.source.Play();
                        break;
                    case AudioAction.STOP:
                        if (!currentJob.fade)
                        {
                            currentTrack.source.Stop();
                        }
                        break;
                    case AudioAction.RESTART:
                        if (!currentJob.fade)
                        {
                            currentTrack.source.Stop();
                            currentTrack.source.Play();
                        }
                        break;
                    default:
                        break;
                }

                if (currentJob.fade)
                {
                    float initial = currentJob.action == AudioAction.START || currentJob.action == AudioAction.RESTART ? 0.0f : 1.0f;
                    float target = initial == 0 ? musicVolumeLevel : 0;
                    float duration = 1.0f;
                    float counter = 0.0f;

                    while (counter <= duration)
                    {
                        currentTrack.source.volume = Mathf.Lerp(initial, target, counter / duration);
                        counter += Time.deltaTime;
                        yield return null;
                    }

                    if (currentJob.action == AudioAction.STOP)
                    {
                        currentTrack.source.Stop();
                    }
                    else if (currentJob.action == AudioAction.RESTART)
                    {
                        currentTrack.source.Stop();
                        currentTrack.source.Play();
                    }
                }

                jobTable.Remove(currentJob.type);

                Log($"Jobs Count : {jobTable.Count}");

                yield return null;
            }

            private AudioClip GetAudioClipFromAudioTrack(MyAudioType type, AudioTrack track)
            {
                foreach (AudioObject obj in track.audios)
                {
                    if (obj.type == type)
                    {
                        return obj.clip;
                    }
                }

                return null;
            }

            private void RemoveConflictJobs(MyAudioType audioType)
            {
                if (jobTable.ContainsKey(audioType))
                {
                    RemoveJob(audioType);
                }

                MyAudioType conflictAudio = MyAudioType.None;

                foreach (DictionaryEntry entry in jobTable)
                {
                    MyAudioType _audioType = (MyAudioType)entry.Key;
                    AudioTrack audioTrackInUse = (AudioTrack)audioTable[_audioType];
                    AudioTrack audioTrackNeeded = (AudioTrack)audioTable[audioType];

                    if (audioTrackNeeded.source == audioTrackInUse.source)
                    {
                        conflictAudio = _audioType;
                    }
                }

                if (conflictAudio != MyAudioType.None)
                {
                    RemoveJob(conflictAudio);
                }
            }

            private void GenerateAudioTable()
            {
                foreach (AudioTrack track in tracks)
                    foreach (AudioObject obj in track.audios)
                    {
                        if (audioTable.ContainsKey(obj.type))
                            LogWarning($"You are trying to register audio [{ obj.type}] that has already been registered");
                        else
                        {
                            audioTable.Add(obj.type, track);
                            Log($"Registering Audio : [{obj.type}]. ");
                        }

                    }
            }

            private void Log(string message)
            {
                if (!debug) return;
                Debug.Log($"[Audio Controller]:{message}");
            }

            private void LogWarning(string message)
            {
                if (!debug) return;
                Debug.LogWarning($"[Audio Controller]:{message}");
            }
        }
    }
}
