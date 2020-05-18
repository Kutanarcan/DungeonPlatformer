using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuController : MonoBehaviour
{
    [SerializeField]
    Canvas optionCanvas;
    [SerializeField]
    Canvas customizeControlCanvas;

    [SerializeField]
    GameObject inputControl;
    [SerializeField]
    GameObject parentInputPanel;


    bool isInputInitialized;

    static Dictionary<InputType, GameObject> inputObjects = new Dictionary<InputType, GameObject>();

    void InitializeInputControls()
    {
        Dictionary<InputType, KeyInfo> tmpDefaultDict = InputManager.Instance.inputInfo.keyInputDict;

        foreach (var input in tmpDefaultDict)
        {
            GameObject tmp = Instantiate(inputControl, transform.position, transform.rotation);
            Button button = tmp.GetComponentInChildren<Button>();
            TextMeshProUGUI codeText = button.GetComponentInChildren<TextMeshProUGUI>();

            inputObjects.Add(input.Value.inputType, tmp);

            tmp.transform.SetParent(parentInputPanel.transform, false);
            tmp.GetComponentInChildren<TextMeshProUGUI>().text = input.Value.inputName;
            button.onClick.AddListener(() => { InputManager.Instance.SetKeyCode(input.Key, codeText); });
            codeText.text = input.Value.inputCode.ToString();
        }
    }   

    public void OpenCustomizeControlPanel()
    {
        if (!isInputInitialized)
        {
            isInputInitialized = true;
            InitializeInputControls();
        }

        optionCanvas.enabled = false;
        customizeControlCanvas.enabled = true;
    }

    public void BackToOptions()
    {
        optionCanvas.enabled = true;
        customizeControlCanvas.enabled = false;
    }

    public static void ChangeInputText(InputType type, KeyCode code)
    {
        inputObjects[type].GetComponentInChildren<Button>().GetComponentInChildren<TextMeshProUGUI>().text = code.ToString();
    }
}
