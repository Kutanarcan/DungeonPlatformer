using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityCore.Audio;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown resolutionDropdown;
    [SerializeField]
    TMP_Dropdown qualityDropdown;
    [SerializeField]
    Slider musicVolumeSlider;
    [SerializeField]
    Slider SFXVolumeSlider;

    Resolution[] resolutions;

    #region SaveDataVariables

    public int ResolutionIndex { get; private set; }
    public float MusicVolume { get; private set; } = 1f;
    public float SFXVolume { get; private set; } = 1f;
    public int QualityIndex { get; private set; } = 0;
    public bool IsFullScreen { get; private set; } = true;

    #endregion

    public const string SAVE_SETTINGS_FILE_NAME = "Settings.dat";

    private void Awake()
    {
        InitializeResolutionDropdown();
    }

    private void Start()
    {
        Load();
    }

    void InitializeResolutionDropdown()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = $"{resolutions[i].width}x{resolutions[i].height}";
            options.Add(option);

            if (resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        ResolutionIndex = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusicVolume(float musicVolume)
    {
        AudioManager.Instance.SetMusicVolumeLevel(musicVolume);
        MusicVolume = musicVolume;
    }

    public void SetSFXVolume(float SFXVolume)
    {
        AudioManager.Instance.SetSFXVolumeLevel(SFXVolume);
        this.SFXVolume = SFXVolume;
    }

    public void SetQuality(int qualtyIndex)
    {
        QualitySettings.SetQualityLevel(qualtyIndex);
        QualityIndex = qualtyIndex;
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        IsFullScreen = isFullScreen;
    }

    public void Save()
    {
        SettingsData settingsData = new SettingsData(this);
        SaveManager.Save(settingsData, SAVE_SETTINGS_FILE_NAME);
    }

    public void Load()
    {
        SettingsData loadSettingsData = SaveManager.Load<SettingsData>(SAVE_SETTINGS_FILE_NAME);

        if (loadSettingsData!=null)
        {
            SetMusicVolume(loadSettingsData.musicVolume);
            SetSFXVolume(loadSettingsData.SFXVolume);
            SetQuality(loadSettingsData.qualityIndex);
            SetFullScreen(loadSettingsData.isFullScreen);
            SetResolution(loadSettingsData.resolutionIndex);

            UpdateSettingsUI(loadSettingsData);
        }
    }

    public void UpdateSettingsUI(SettingsData loadSettingsData)
    {
        resolutionDropdown.value = loadSettingsData.resolutionIndex;
        qualityDropdown.value = loadSettingsData.qualityIndex;
        musicVolumeSlider.value = loadSettingsData.musicVolume;
        SFXVolumeSlider.value = loadSettingsData.SFXVolume;
        resolutionDropdown.RefreshShownValue();
        qualityDropdown.RefreshShownValue();
    }
}
