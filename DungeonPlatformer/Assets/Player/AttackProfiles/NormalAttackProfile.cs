using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NormalAttackProfile", menuName ="Attack/NormalAttack")]
public class NormalAttackProfile : AttackProfile
{
    public NormalAttackType normalAttackType;
}

public enum NormalAttackType
{
    Sword = 0,
    Axe = 10
}
