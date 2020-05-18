using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    Item item;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            Inventory.Instance.AddItem(item);
            Destroy(gameObject);
        }
    }
}
