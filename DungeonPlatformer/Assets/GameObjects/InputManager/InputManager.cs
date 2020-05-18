using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputInfo inputInfo;

    [SerializeField]
    List<KeyCode> forbiddenKeyChange = new List<KeyCode>();

    public static InputManager Instance { get; private set; }

    Event keyEvent;
    KeyCode newKey;
    bool waitingForKey;
    public bool IsInGame { get; set; } = false;
    InputData inputData;

    const string INPUT_SAVE_FILE_NAME = "Input.dat";


    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        waitingForKey = false;
        inputInfo = new InputInfo();
    }

    void Start()
    {
        inputData = new InputData(inputInfo);

        LoadInputData();
    }

    void OnGUI()
    {
        if (!IsInGame)
        {
            keyEvent = Event.current;

            if (keyEvent.isKey && waitingForKey)
            {
                newKey = (KeyCode)keyEvent.keyCode;
                waitingForKey = false;
            }
        }
    }

    public void SetKeyCode(InputType keyType, TextMeshProUGUI codeText)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyType, codeText));
    }

    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    InputType swapType;

    IEnumerator AssignKey(InputType keyType, TextMeshProUGUI codeText)
    {

        waitingForKey = true;

        PopupManager.Instance.ShowInputControlMessage();
        yield return WaitForKey();
        PopupManager.Instance.HideInputControlMessage();

        if (!IsKeyCodeInForbiddenList())
        {
            if (inputInfo.keyInputDict[keyType].inputCode == newKey)
            {
                PopupManager.Instance.ShowStandartPopup("You cannot change same key");
            }
            else if (IsSwapRequire())
            {
                SwapKeys();
                OptionsMenuController.ChangeInputText(keyType, inputInfo.keyInputDict[keyType].inputCode);
                OptionsMenuController.ChangeInputText(swapType, inputInfo.keyInputDict[swapType].inputCode);

                SaveManager.Save(inputData, INPUT_SAVE_FILE_NAME);
            }
            else
            {
                inputInfo.keyInputDict[keyType].inputCode = newKey;
                codeText.text = newKey.ToString();

                SaveManager.Save(inputData, INPUT_SAVE_FILE_NAME);
            }
        }
        else
        {
            PopupManager.Instance.ShowStandartPopup($"{newKey} is a Forbidden Key Change, Try Another Key.");
        }

        bool IsKeyCodeInForbiddenList()
        {
            return forbiddenKeyChange.Contains(newKey);
        }
        bool IsSwapRequire()
        {
            foreach (var input in inputInfo.keyInputDict)
            {
                if (input.Value.inputCode == newKey)
                {
                    swapType = input.Key;
                    return true;
                }
            }
            return false;
        }
        void SwapKeys()
        {
            inputInfo.keyInputDict[keyType].inputCode = inputInfo.keyInputDict[keyType].inputCode ^ inputInfo.keyInputDict[swapType].inputCode;
            inputInfo.keyInputDict[swapType].inputCode = inputInfo.keyInputDict[keyType].inputCode ^ inputInfo.keyInputDict[swapType].inputCode;
            inputInfo.keyInputDict[keyType].inputCode = inputInfo.keyInputDict[keyType].inputCode ^ inputInfo.keyInputDict[swapType].inputCode;
        }
    }

    public void LoadInputData()
    {
        InputData loadData = SaveManager.Load<InputData>(INPUT_SAVE_FILE_NAME);

        if (loadData != null)
        {
            List<KeyInfo> inputs = loadData.inputList;

            for (int i = 0; i < inputs.Count; i++)
            {
                if (inputInfo.keyInputDict.ContainsKey(inputs[i].inputType))
                {
                    inputInfo.keyInputDict.Remove(inputs[i].inputType);
                    inputInfo.keyInputDict.Add(inputs[i].inputType, inputs[i]);
                }
            }
        }
    }
}
