using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRoarState : IState
{
    public float RoarTime { get; private set; } = 5f;
    public float Timer { get; private set; }

    Demon demon;
    GameObject roarEffect;
    DemonMovement demonMovement;

    public void OnStateEnter()
    {
        Timer = 0f;
        demon.IsRoarFinished = false;
        roarEffect.SetActive(true);
        demonMovement.ResetDirection();
    }

    public void Tick()
    {
        if (Timer < RoarTime)
            Timer += TimeManager.deltaTime;
        else
            demon.IsRoarFinished = true;
    }

    public void OnStateExit()
    {
        roarEffect.SetActive(false);
    }

    public DemonRoarState(Demon demon, GameObject roarEffect, DemonMovement demonMovement)
    {
        this.demon = demon;
        this.roarEffect = roarEffect;
        this.demonMovement = demonMovement;
    }
}
