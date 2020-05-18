using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    const float EXPLOSION_DAMAGE = 50F;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IBombTarget target = other.GetComponent<IBombTarget>();

        if (target != null)
        {
            target.DamageWithBomb(EXPLOSION_DAMAGE);
        }
    }
}
