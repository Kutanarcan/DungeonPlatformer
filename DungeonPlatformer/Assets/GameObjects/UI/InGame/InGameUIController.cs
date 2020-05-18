using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    UI_Base ui_base;

    [SerializeField]
    Canvas pauseCanvas;

    void Awake()
    {
        ui_base = GetComponentInParent<UI_Base>();
    }

    void OnEnable()
    {
        InGameEvents.OnMainMenuButtonPressed += InGameEvents_OnMainMenuButtonPressed;
    }

    private void InGameEvents_OnMainMenuButtonPressed()
    {
        ClosePauseMenu();
    }

    private void OnDisable()
    {
        InGameEvents.OnMainMenuButtonPressed -= InGameEvents_OnMainMenuButtonPressed;
    }

    public void OpenPauseMenu()
    {
        pauseCanvas.enabled = true;
        TimeManager.timeScale = 0;
        InGameEvents.OnGamePausedFunction();
    }

    public void ClosePauseMenu()
    {
        pauseCanvas.enabled = false;
        TimeManager.timeScale = 1;
        InGameEvents.OnGameContinueFunction();

    }

    public void ResumeButton()
    {
        ClosePauseMenu();
    }
}
