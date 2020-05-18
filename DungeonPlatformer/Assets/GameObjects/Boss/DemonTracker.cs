using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonTracker : MonoBehaviour
{
    [SerializeField]
    Transform demonRoarPos;
    [SerializeField]
    Transform demonRestPos;

    public Transform GetRoarPos()
    {
        return demonRoarPos;
    }

    public Transform GetRestPos()
    {
        return demonRestPos;
    }
}
