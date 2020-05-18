using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewConversation", menuName = "Dialog/Conversation")]
public class Conversation : ScriptableObject
{
    public List<ConversationHolder> conversations = new List<ConversationHolder>();
}

[System.Serializable]
public struct ConversationHolder
{
    public Speaker speaker;
    [TextArea(10, 30)]
    public string dialog;
}
