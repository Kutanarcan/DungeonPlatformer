using System;
using UnityEngine;

public enum ItemType
{
    Consume = 0,
    Use = 10,
    Equip = 20
}

public abstract class Item : ScriptableObject,IComparable
{
    public ItemBaseController itemPrefab;
    public string itemName;
    public Sprite icon;
    [TextArea(5, 10)]
    public string description;
    public bool stackable;
    public abstract ItemType ItemType { get; }

    Item tmp;

    public int CompareTo(object obj)
    {
        if (obj is Item)
            tmp = (Item)obj;

        return ItemType.CompareTo(tmp.ItemType);
    }

    public virtual void UseItem()
    {
        itemPrefab.UseItem();
    }
}
