using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonCloseAttackState : IState
{
    private Demon demon;
    private DemonAnimator demonAnimator;

    public void OnStateEnter()
    {
        demon.IsAttackFinished = false;
        demonAnimator.SetCloseAttackTrigger();
    }

    public void Tick()
    {
        Debug.Log("Close Attack State Tick");
    }

    public void OnStateExit()
    {
        Debug.Log("Close Attack State Exit");
    }

    public DemonCloseAttackState(Demon demon, DemonAnimator demonAnimator)
    {
        this.demon = demon;
        this.demonAnimator = demonAnimator;
    }
}
