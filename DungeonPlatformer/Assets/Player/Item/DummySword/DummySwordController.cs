using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySwordController : ItemBaseController
{
    [SerializeField]
    private EquipableItem equipableItem;

    public override void UseItem()
    {
        Debug.Log("Equiping Dummy Sword");
    }
}
