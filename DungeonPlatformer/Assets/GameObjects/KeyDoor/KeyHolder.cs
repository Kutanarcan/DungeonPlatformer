using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<KeyType> keylist;

    private void Awake()
    {
        keylist = new List<KeyType>();
    }

    public void AddKey(KeyType keyType)
    {
        keylist.Add(keyType);
        Debug.Log(keyType);
    }

    public void RemoveKey(KeyType keyType)
    {
        keylist.Remove(keyType);
    }

    public bool ContainsKey(KeyType keyType)
    {
        return keylist.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Key key = other.GetComponent<Key>();

        if (key!=null)
        {
            AddKey(key.KeyType);
            Destroy(key.gameObject);
        }

        IDoor keyDoor = other.GetComponent<IDoor>();

        if (keyDoor != null)
        {
            if (ContainsKey(keyDoor.KeyType))
            {
                keyDoor.OpenDoor();
            } 
        }
    }
}

