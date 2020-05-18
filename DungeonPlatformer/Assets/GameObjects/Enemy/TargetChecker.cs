using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    Enemy_Base enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy_Base>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            enemy.Target = other.gameObject.transform;
            Debug.Log(enemy.Target.gameObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            enemy.Target = null;
            Debug.Log(enemy.Target);
        }
    }
}
