using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    public Dictionary<SkillType, Skill> SkillDict { get; private set; } = new Dictionary<SkillType, Skill>();
    PlayerSkills playerSkills;

    void Awake()
    {
        playerSkills = new PlayerSkills();
        playerSkills.InitializeSkills(SkillDict);
    }

    void OnEnable()
    {
        PlayerEvents.OnSkillUnlocked += PlayerEvents_OnSkillUnlocked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            playerSkills.UnlockSkill(SkillType.Bomb);
            playerSkills.UnlockSkill(SkillType.WallJump);
        }
    }

    private void PlayerEvents_OnSkillUnlocked(SkillType skill)
    {
        if (SkillDict.ContainsKey(skill))
        {
            SkillDict.Remove(skill);
            SkillDict.Add(skill, new Skill(true, skill));
        }
    }

    public void LoadSkillData(List<Skill> skills)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (SkillDict.ContainsKey(skills[i].type))
            {
                SkillDict.Remove(skills[i].type);
                SkillDict.Add(skills[i].type, skills[i]);
            }
        }
    }

    void OnDisable()
    {
        PlayerEvents.OnSkillUnlocked -= PlayerEvents_OnSkillUnlocked;
    }
}
