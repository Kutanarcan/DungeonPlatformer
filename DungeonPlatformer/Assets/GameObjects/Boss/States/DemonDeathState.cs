using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDeathState : IState
{
    public void OnStateEnter()
    {
        Debug.Log("Death State Enter");
    }

    public void Tick()
    {
        Debug.Log("Death State Tick");
    }

    public void OnStateExit()
    {
        Debug.Log("Death State Exit");
    }
}
