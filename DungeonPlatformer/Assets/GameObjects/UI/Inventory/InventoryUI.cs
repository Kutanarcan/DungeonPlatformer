using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance { get; private set; }

    [SerializeField]
    Canvas inventoryPanel;
    [SerializeField]
    Transform parentInventoryPanel;

    InventorySlot[] inventorySlots;
    Inventory inventory;

    Dictionary<string, InventorySlot> stackableItemDict = new Dictionary<string, InventorySlot>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        inventory = Inventory.Instance;
        InGameEvents.OnInventoryModified += UpdateInventory;
        inventorySlots = parentInventoryPanel.GetComponentsInChildren<InventorySlot>();
        UpdateInventory();
    }

    void UpdateInventory()
    {
        stackableItemDict.Clear();
        int itemCounter = 0;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            while (itemCounter < inventory.Items.Count)
            {
                if (!stackableItemDict.ContainsKey(inventory.Items[itemCounter].itemName) && i < inventorySlots.Length)
                {
                    inventorySlots[i].AddItem(inventory.Items[itemCounter]);

                    if (inventory.Items[itemCounter].stackable)
                        stackableItemDict.Add(inventory.Items[itemCounter].itemName, inventorySlots[i]);

                    i++;
                }
                else if(stackableItemDict.ContainsKey(inventory.Items[itemCounter].itemName))
                {
                    InventorySlot slot = stackableItemDict[inventory.Items[itemCounter].itemName];
                    slot.Amount++;
                    slot.UpdateAmountText();
                }
                itemCounter++;
            }

            if (i < inventorySlots.Length)
                inventorySlots[i].ClearSlot();
        }
    }

    public void SetVisibilityInventoryPanel()
    {
        inventoryPanel.enabled = !inventoryPanel.enabled;
        UpdateInventory();
    }

    public bool IsInventoryFull()
    {
        return !inventorySlots[inventorySlots.Length - 1].IsEmpty;
    }
}
