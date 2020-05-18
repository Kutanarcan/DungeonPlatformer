using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveController : MonoBehaviour
{
    PlayerController playerController;
    PlayerData playerData;

    const string SAVE_FILE_NAME = "Player.dat";

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void SavePlayerData()
    {
        playerData = new PlayerData(playerController);
        SaveManager.Save(playerData, SAVE_FILE_NAME);
    }

    public void LoadAllPlayerData()
    {
        PlayerData loadData = SaveManager.Load<PlayerData>(SAVE_FILE_NAME);
        if (loadData != null)
        {
            transform.position = loadData.position;
            playerController.PlayerSkillController.LoadSkillData(loadData.skillist);
        }
    }
}
