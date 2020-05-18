using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    None,
    DungeonKey,
    GoldenKey,
    SilverKey
}

public class Key : MonoBehaviour
{
    [SerializeField]
    KeyType keyType;

    public KeyType KeyType { get => keyType; set => keyType = value; }
}

