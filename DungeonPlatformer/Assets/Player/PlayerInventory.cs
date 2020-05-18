using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    PlayerController playerController;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void HealthPotion(ConsumableItem consumable)
    {
        playerController.HealthController.CurrentHealth += consumable.restoreAmount;
        playerController.HealthDisplayController.UpdateHealthBar();
    }
}
