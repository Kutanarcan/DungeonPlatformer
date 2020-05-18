using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    Coroutine conversationCoroutine;
    Queue<ConversationHolder> conversations = new Queue<ConversationHolder>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        InGameEvents.OnDialogContinueButtonPressed += ContinueConversation;
    }

    public void StartConversation(Conversation conversation)
    {
        InGameEvents.OnDialogStartedFunction();
        UI_Base.Instance.DialogDisplayer.SetDialogBox(true);
        ConvertDialogsToQueue(conversation);
        conversationCoroutine = StartCoroutine(ConversationCoroutine());
    }

    public void ContinueConversation()
    {
        conversationCoroutine = StartCoroutine(ConversationCoroutine());
    }

    void ConvertDialogsToQueue(Conversation currentConversation)
    {
        conversations.Clear();

        for (int i = 0; i < currentConversation.conversations.Count; i++)
        {
            conversations.Enqueue(currentConversation.conversations[i]);
        }
    }

    IEnumerator ConversationCoroutine()
    {
        if (conversations.Count > 0)
        {
            ConversationHolder tmpConversationHolder = conversations.Dequeue();
            UI_Base.Instance.DialogDisplayer.SetConversationSettings(tmpConversationHolder.speaker.Icon, tmpConversationHolder.dialog);
        }
        else
        {
            InGameEvents.OnDialogEndedFunction();
            UI_Base.Instance.DialogDisplayer.SetDialogBox(false);
        }

        yield return null;
    }

    void OnDisable()
    {
        InGameEvents.OnDialogContinueButtonPressed -= ContinueConversation;
    }
}
