using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRangedAttackState : IState
{
    Demon demon;
    DemonAnimator demonAnimator;

    public void OnStateEnter()
    {
        demon.IsAttackFinished = false;
        demonAnimator.SetRangedAttackTrigger();
        Debug.Log("Ranged Attack State Enter");
    }

    public void Tick()
    {
        Debug.Log("Ranged Attack State Tick");
    }

    public void OnStateExit()
    {
        Debug.Log("Ranged Attack State Exit");
    }

    public DemonRangedAttackState(Demon demon, DemonAnimator demonAnimator)
    {
        this.demon = demon;
        this.demonAnimator = demonAnimator;
    }
}
