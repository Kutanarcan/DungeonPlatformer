using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Item/Consumable")]
public class ConsumableItem : Item
{
    public float restoreAmount;

    public override ItemType ItemType => ItemType.Consume;
}
