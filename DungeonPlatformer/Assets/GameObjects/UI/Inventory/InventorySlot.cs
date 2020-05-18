using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    [SerializeField]
    Image icon;
    [SerializeField]
    TextMeshProUGUI amountText;
    public Item Item { get; private set; }
    public int Amount { get; set; }
    public bool IsEmpty { get; private set; } = true;

    public void AddItem(Item newItem)
    {
        Item = newItem;
        icon.sprite = Item.icon;
        icon.enabled = true;
        IsEmpty = false;
        Amount = 1;
        amountText.text = Amount.ToString();
    }

    public void ClearSlot()
    {
        Item = null;
        icon.sprite = null;
        icon.enabled = false;
        IsEmpty = true;
        Amount = 0;
        amountText.text = Amount.ToString();
    }

    private void OnEnable()
    {
        ClearSlot();
    }

    public void UpdateAmountText()
    {
        amountText.text = Amount.ToString();
    }

    public void RemoveItem()
    {
        Inventory.Instance.RemoveItem(Item);
    }

    public void UseItem()
    {
        if (Item != null)
        {
            Item.UseItem();

            if (Amount > 0)
                Amount--;

            RemoveItem();

            InGameEvents.OnInventoryModifiedFunction();
        }
    }
}
