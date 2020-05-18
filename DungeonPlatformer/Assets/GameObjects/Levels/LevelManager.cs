using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    List<LevelBase> levelBases;

    public Dictionary<Level, LevelDataBase> Leveldict { get; private set; } = new Dictionary<Level, LevelDataBase>();

    const string LEVEL_DATA_SAVE_FILE_NAME = "Level.dat";

    private void Start()
    {
        Save();
        Invoke("Load", 3f);
    }

    public void Save()
    {
        Leveldict.Clear();

        for (int i = 0; i < levelBases.Count; i++)
        {
            if (Leveldict.ContainsKey(levelBases[i].Level))
                Debug.LogError($"{levelBases[i].Level} already exist in this Dictionary");
            else
            {
                Leveldict.Add(levelBases[i].Level, levelBases[i].Save());
            }
        }

        LevelData levelData = new LevelData(this);
        SaveManager.Save(levelData, LEVEL_DATA_SAVE_FILE_NAME);
    }

    public void Load()
    {
        LevelData loadLevelData = SaveManager.Load<LevelData>(LEVEL_DATA_SAVE_FILE_NAME);
    }
}
