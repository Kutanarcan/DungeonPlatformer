using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossConversationOpener : MonoBehaviour
{
    [SerializeField]
    Conversation conversation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            DialogManager.Instance.StartConversation(conversation);
        }
    }
}
