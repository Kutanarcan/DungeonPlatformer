using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour,IDoor
{
    [SerializeField]
    KeyType keyType;

    public KeyType KeyType { get => keyType; set => keyType = value; }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
