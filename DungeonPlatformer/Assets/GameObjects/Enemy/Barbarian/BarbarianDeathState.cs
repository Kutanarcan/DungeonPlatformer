using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianDeathState : IState
{
    BarbarianAnimator enemyAnim;

    public void OnStateEnter()
    {
        enemyAnim.SetDeadTrigger();
        enemyAnim.Speed = 0;
        Debug.Log("Death State Entered");
    }

    public void Tick()
    {
        Debug.Log("Death State Working");
    }

    public void OnStateExit()
    {
        Debug.Log("Death State Exitted");
    }

    public BarbarianDeathState(BarbarianAnimator anim)
    {
        enemyAnim = anim;
    }
}
