using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

[CreateAssetMenu(fileName = "SpecialAttackProfiles", menuName = "Attack/SpecialAttacks")]
public class SpecialAttackProfiles : ScriptableObject
{
    public List<SpecialAttackProfile> specialAttackProfiles = new List<SpecialAttackProfile>();

    public Dictionary<InputType, GameObject> AttackDict => attackDict;

    Dictionary<InputType, GameObject> attackDict = new Dictionary<InputType, GameObject>();


    public Dictionary<InputType, MyAudioType> SoundDict => soundDict;

    Dictionary<InputType, MyAudioType> soundDict = new Dictionary<InputType, MyAudioType>();

    void OnEnable()
    {
        foreach (var attack in specialAttackProfiles)
        {
            attackDict.Add(attack.inputType, attack.prefab);
            soundDict.Add(attack.inputType, attack.audioType);
        }
    }
}
