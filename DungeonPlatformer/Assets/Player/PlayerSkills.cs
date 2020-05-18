using System.Collections.Generic;

public enum SkillType
{
    WallJump = 0,
    Bomb =10
}
[System.Serializable]
public struct Skill
{
    public bool activeness;
    public SkillType type;

    public Skill(bool active, SkillType type)
    {
        activeness = active;
        this.type = type;
    }
}

public class PlayerSkills
{
    List<SkillType> unlockedSkillTypes;

    public PlayerSkills()
    {
        unlockedSkillTypes = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skill)
    {
        unlockedSkillTypes.Add(skill);
        PlayerEvents.OnSkillUnlockedFunc(skill);
    }

    public bool IsSkillUnlocked(SkillType skill)
    {
        return unlockedSkillTypes.Contains(skill);
    }

    public void InitializeSkills(Dictionary<SkillType, Skill> skillDict)
    {
        //This could be ScriptableObject
        skillDict.Add(SkillType.WallJump, new Skill(false, SkillType.WallJump));
        skillDict.Add(SkillType.Bomb, new Skill(false, SkillType.Bomb));
    }
}
