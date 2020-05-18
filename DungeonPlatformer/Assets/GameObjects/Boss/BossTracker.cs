using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTracker : MonoBehaviour
{
    public static BossTracker Instance { get; private set; }

    public DemonTracker DemonTracker { get; private set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        DemonTracker = GetComponentInChildren<DemonTracker>();
    }
}
