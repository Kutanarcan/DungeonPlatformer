using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

public class UI_Base : MonoBehaviour
{
    public static UI_Base Instance { get; private set; }
    public MainMenuController MainMenuController { get; private set; }
    public FadeSceneController FadeSceneController { get; private set; }
    public InGameUIController InGameUIController { get; private set; }
    public DialogDisplayer DialogDisplayer { get; private set; }
    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        MainMenuController = GetComponentInChildren<MainMenuController>();
        FadeSceneController = GetComponentInChildren<FadeSceneController>();
        InGameUIController = GetComponentInChildren<InGameUIController>();
        DialogDisplayer = GetComponentInChildren<DialogDisplayer>();
    }

    void Start()
    {
        AudioManager.Instance.Play(MyAudioType.Main_Menu1, fade: true, delay: 0.5f);

    }

    void OnEnable()
    {
        UIEvents.OnGameStartButtonPressed += UIEvents_OnGameStartButtonPressed;
        InGameEvents.OnGameStart += InGameEvents_OnGameStart;
        InGameEvents.OnMainMenuButtonPressed += InGameEvents_OnMainMenuButtonPressed;
    }

    private void InGameEvents_OnMainMenuButtonPressed()
    {
        MainMenuController.GetComponentInChildren<Canvas>().enabled = true;
        FadeSceneController.GetComponentInChildren<Canvas>().enabled = false;
        InGameUIController.GetComponentInChildren<Canvas>().enabled = false;
        AudioManager.Instance.Stop(MyAudioType.InGame_Level1, fade: true);
        AudioManager.Instance.Play(MyAudioType.Main_Menu1, fade: true, delay: 0.5f);
        InputManager.Instance.IsInGame = false;
    }

    private void InGameEvents_OnGameStart()
    {
        MainMenuController.GetComponentInChildren<Canvas>().enabled = false;
        FadeSceneController.GetComponentInChildren<Canvas>().enabled = false;
        InGameUIController.GetComponentInChildren<Canvas>().enabled = true;
    }

    private void UIEvents_OnGameStartButtonPressed()
    {
        InputManager.Instance.IsInGame = true;
        MainMenuController.GetComponentInChildren<Canvas>().enabled = false;
        AudioManager.Instance.Stop(MyAudioType.Main_Menu1, fade: true);
        AudioManager.Instance.Play(MyAudioType.InGame_Level1, fade: true, delay: 0.5f);
    }

    void OnDisable()
    {
        UIEvents.OnGameStartButtonPressed -= UIEvents_OnGameStartButtonPressed;
        InGameEvents.OnGameStart -= InGameEvents_OnGameStart;
        InGameEvents.OnMainMenuButtonPressed -= InGameEvents_OnMainMenuButtonPressed;
    }
}
