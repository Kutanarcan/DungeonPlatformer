using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    public List<Item> Items { get; private set; } = new List<Item>();

    GameObject itemControllerPrefab;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public bool AddItem(Item item)
    {
        if (InventoryUI.Instance.IsInventoryFull() && Items.Contains(item) && item.stackable)
        {
            HandleItemAdd();
            return true;
        }

        else if (InventoryUI.Instance.IsInventoryFull())
            return false;

        HandleItemAdd();
        return true;

        void HandleItemAdd()
        {
            Items.Add(item);
            Items.Sort();

            InGameEvents.OnInventoryModifiedFunction();
        }
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
}
