using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IBombTarget
{
    public void DamageWithBomb(float damageAmount)
    {
        gameObject.SetActive(false);
    }
}
