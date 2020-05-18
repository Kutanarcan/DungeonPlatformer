using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionController : ItemBaseController
{
    [SerializeField]
    ConsumableItem consumableItem;

    public override void UseItem()
    {
        PlayerController.Instance.PlayerInventory.HealthPotion(consumableItem);
    }
}
