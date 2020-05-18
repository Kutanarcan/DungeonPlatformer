using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDoor
{
    void OpenDoor();
    KeyType KeyType { get; set; }
}
