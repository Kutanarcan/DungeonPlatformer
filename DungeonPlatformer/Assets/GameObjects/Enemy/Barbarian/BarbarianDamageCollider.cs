using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianDamageCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerDamageController playerDamageController= other.GetComponent<PlayerDamageController>();

        if (playerDamageController!=null)
        {
            playerDamageController.TakeDamage(7f);
        }
    }
}
