using UnityEngine;

[CreateAssetMenu(fileName = "EquipableItem", menuName = "Item/Equipable")]
public class EquipableItem : Item
{
    public EquipmentSlot equipmentSlot;
    public int attackBonus;
    public int defenceBonus;
    public override ItemType ItemType => ItemType.Equip;
}

public enum EquipmentSlot{ Head, Chest, Legs, Weapon, Shield, Feet }
