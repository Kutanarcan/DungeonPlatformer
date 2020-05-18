using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour, IDoor, IBombTarget
{
    public KeyType KeyType { get; set; } = KeyType.None;

    public void DamageWithBomb(float damageAmount)
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
