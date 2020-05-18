using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour, IInteractable
{
    Mike mikeBase;

    void Awake()
    {
        mikeBase = GetComponentInParent<Mike>();
    }

    public void Interact()
    {
        DialogManager.Instance.StartConversation(mikeBase.GetConversation());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            mikeBase.MikeInteractionDisplayer.ShowInteractionCanvas();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            mikeBase.MikeInteractionDisplayer.HideInteractionCanvas();
        }
    }
}
