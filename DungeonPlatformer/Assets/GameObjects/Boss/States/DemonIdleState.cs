using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonIdleState : IState
{
    DemonAnimator demonAnimator;

    public void OnStateEnter()
    {
    }

    public void Tick()
    {
        Debug.Log("Demon Idle State Tick");
    }

    public void OnStateExit()
    {
        demonAnimator.IsFlying = true;
    }

    public DemonIdleState(DemonAnimator demonAnimator)
    {
        this.demonAnimator = demonAnimator;
    }

}
