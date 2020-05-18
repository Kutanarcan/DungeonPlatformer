using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public int resolutionIndex;
    public float musicVolume;
    public float SFXVolume;
    public int qualityIndex;
    public bool isFullScreen;

    public SettingsData(SettingsController settingsController)
    {
        resolutionIndex = settingsController.ResolutionIndex;
        musicVolume = settingsController.MusicVolume;
        SFXVolume = settingsController.SFXVolume;
        qualityIndex = settingsController.QualityIndex;
        isFullScreen = settingsController.IsFullScreen;
    }
}
