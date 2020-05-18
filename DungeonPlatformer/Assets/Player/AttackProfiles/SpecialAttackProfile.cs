using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

[CreateAssetMenu(fileName = "SpecialAttackProfile", menuName = "Attack/SpecialAttack")]
public class SpecialAttackProfile : AttackProfile
{
    public InputType inputType;
    public SpecialAttackType specialAttackType;
    public MyAudioType audioType;
}

public enum SpecialAttackType
{
    Fireball = 0,
    IceProjectTile = 10 
}
