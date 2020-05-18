using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public Vector3 position;
    public List<Skill> skillist;

    public PlayerData(PlayerController playerController)
    {
        position = playerController.transform.position;
        skillist = playerController.PlayerSkillController.SkillDict.SaveDictionary();
    }

}
