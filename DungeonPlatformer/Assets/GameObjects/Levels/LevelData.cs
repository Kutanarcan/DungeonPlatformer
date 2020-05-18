using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public List<LevelDataBase> levelDataBases;

    public LevelData(LevelManager levelManager)
    {
        levelDataBases = levelManager.Leveldict.SaveDictionary();
    }
}
