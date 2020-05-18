using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mike : NPC_Base
{
    [SerializeField]
    List<Conversation> standartConversation;

    public bool CanInteract { get; set; } = false;
    public Stack<Conversation> ConversationsStack { get; set; } = new Stack<Conversation>();
    public MikeInteractionDisplayer MikeInteractionDisplayer { get; private set; }

    void Awake()
    {
        MikeInteractionDisplayer = GetComponentInChildren<MikeInteractionDisplayer>();
        InitializeConversationStack();
    }

    void InitializeConversationStack()
    {
        for (int i = standartConversation.Count; i > 0; i--)
        {
            AddConversation(standartConversation[i - 1]);
        }
    }

    public void AddConversation(Conversation conversation)
    {
        ConversationsStack.Push(conversation);
    }

    public Conversation GetConversation()
    {
        if (ConversationsStack.Count > 1)
        {
            return ConversationsStack.Pop();
        }
        else
        {
            return ConversationsStack.Peek();
        }
    }
}
