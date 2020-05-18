using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackController : MonoBehaviour
{
    [SerializeField]
    protected AttackProfile attackProfile;
    [SerializeField]
    protected float movementSpeed;

    public abstract float Cooldown { get; set; }
    public abstract void DoAttack();
}
