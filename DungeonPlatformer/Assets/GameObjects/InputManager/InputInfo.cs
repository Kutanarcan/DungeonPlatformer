using System.Collections.Generic;
using UnityEngine;

public class InputInfo
{
    public Dictionary<InputType, KeyInfo> keyInputDict;

    public InputInfo()
    {
        keyInputDict = new Dictionary<InputType, KeyInfo>();

        keyInputDict.Add(InputType.Attack, new KeyInfo { inputType = InputType.Attack, inputName = "Sword", inputCode = KeyCode.R });
        keyInputDict.Add(InputType.Fireball, new KeyInfo { inputType = InputType.Fireball, inputName = "Fireball", inputCode = KeyCode.Q });
        keyInputDict.Add(InputType.Icebolt, new KeyInfo { inputType = InputType.Icebolt, inputName = "Icebolt", inputCode = KeyCode.E });
        keyInputDict.Add(InputType.Jump, new KeyInfo { inputType = InputType.Jump, inputName = "Jump", inputCode = KeyCode.Space });
        keyInputDict.Add(InputType.Inventory, new KeyInfo { inputType = InputType.Inventory, inputName = "Inventory", inputCode = KeyCode.I });
        keyInputDict.Add(InputType.Bomb, new KeyInfo { inputType = InputType.Bomb, inputName = "Bomb", inputCode = KeyCode.B });
    }
}
[System.Serializable]
public class KeyInfo
{
    public InputType inputType;
    public string inputName;
    public KeyCode inputCode;
}

public enum InputType
{
    None = 0,
    Fireball = 10,
    Jump = 20,
    Icebolt = 30,
    Attack = 40,
    Inventory = 50,
    Bomb = 60
}