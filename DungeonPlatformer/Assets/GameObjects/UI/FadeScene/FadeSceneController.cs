using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeSceneController : MonoBehaviour
{
    UI_Base ui_base;
    Animator anim;

    int paramFadeIn = Animator.StringToHash("FadeIn");
    int paramFadeOut = Animator.StringToHash("FadeOut");

    public const string MAIN_MENU = "MainMenu";
    public const string GAME = "Game";
    string sceneName;

    private void Awake()
    {
        ui_base = GetComponentInParent<UI_Base>();
        anim = GetComponent<Animator>();
    }

    public void StartFadeIn(string sceneName)
    {
        this.sceneName = sceneName;
        anim.SetTrigger(paramFadeIn);
    }

    public void LoadTheScene()
    {
        switch (sceneName)
        {
            case MAIN_MENU:
                GameManager.Instance.BackToMainMenu();
                break;
            case GAME:
                ui_base.MainMenuController.StartGame();
                break;
            default:
                break;
        }

        anim.SetTrigger(paramFadeOut);
    }

    public void OnFadeOutFinished()
    {
        switch (sceneName)
        {
            case MAIN_MENU:
                break;
            case GAME:
                InGameEvents.OnGameStartFunction();
                break;
            default:
                break;
        }
    }
}
