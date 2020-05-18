using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputData
{
    public List<KeyInfo> inputList;

    public InputData(InputInfo inputInfo)
    {
        inputList = inputInfo.keyInputDict.SaveDictionary();
    }
}
