using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewSpeaker",menuName ="Dialog/Speaker")]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public Sprite Icon;
}
