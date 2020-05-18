using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

public class SwordAttackController : AttackController, IAttack
{
    public override float Cooldown { get => 0.5f; set { } }

    public override void DoAttack()
    {
        AudioManager.Instance.Play(MyAudioType.Player_Sword);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable!=null)
        {
            damageable.TakeDamage(attackProfile.damage);
        }
    }
}
