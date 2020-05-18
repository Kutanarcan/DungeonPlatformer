using System;

public static class PlayerEvents
{
    public static event Action<float> OnPlayerTakeDamage;
    public static event Action OnPlayerDied;
    public static event Action<SkillType> OnSkillUnlocked;

    public static void OnPlayerTakeDamageFunction(float damageAmount)
    {
        OnPlayerTakeDamage?.Invoke(damageAmount);
    }

    public static void OnPlayerDiedFunction()
    {
        OnPlayerDied?.Invoke();
    }

    public static void OnSkillUnlockedFunc(SkillType skill)
    {
        OnSkillUnlocked?.Invoke(skill);
    }
}
