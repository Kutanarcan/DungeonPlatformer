using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectileAttackController : AttackController, ISpecialAttack
{
    public override float Cooldown { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    Vector2 direction = Vector2.right;

    public override void DoAttack()
    {

    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(direction * movementSpeed * TimeManager.deltaTime);
    }
}
