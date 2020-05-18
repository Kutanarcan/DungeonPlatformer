using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float maxHealth;
    [SerializeField]
    float currentHealth;

    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }
    }

    public float MaxHealth => maxHealth;
  
}
