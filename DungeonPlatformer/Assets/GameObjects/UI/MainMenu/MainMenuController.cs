using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityCore.Audio;

public class MainMenuController : MonoBehaviour
{
    UI_Base ui_base;
    [SerializeField]
    Canvas optionCanvas;
    [SerializeField]
    Canvas mainCanvas;
    [SerializeField]
    SettingsController settingsController;

    private void Awake()
    {
        ui_base = GetComponentInParent<UI_Base>();
    }

    public void StartGame()
    {
        StartCoroutine(LoadSceneWithASyncCoroutine());
        UIEvents.OnGameStartButtonPressedFunction();
    }

    public void Options()
    {
        mainCanvas.enabled = false;
        optionCanvas.enabled = true;
    }

    public void BackToMain()
    {
        mainCanvas.enabled = true;
        optionCanvas.enabled = false;
        settingsController.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadSceneWithASyncCoroutine()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(FadeSceneController.GAME);

        while (!operation.isDone)
        {
            yield return null;
        }
    }

    #region SoundEffectCalls

    public void MenuButtonGetHovered()
    {
        AudioManager.Instance.Play(MyAudioType.Btn_Hover_SFX);
    }

    public void MenuButtonGetClicked()
    {
        AudioManager.Instance.Play(MyAudioType.Swipe_Menus_SFX);
    }

    public void StartGameButtonGetClicked()
    {
        AudioManager.Instance.Play(MyAudioType.StartGame_Button_SFX);
    }

    public void DropDownClicked()
    {
        AudioManager.Instance.Play(MyAudioType.DropDown_SFX);
    }

    public void DragSlider()
    {
        AudioManager.Instance.Play(MyAudioType.SliderScrolling);
    }
    #endregion
}
