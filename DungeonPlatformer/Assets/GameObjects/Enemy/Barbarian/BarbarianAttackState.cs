using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianAttackState : IState
{
    BarbarianAnimator enemyAnim;
    float reAttackTimer = 2f;
    float timer;

    public void OnStateEnter()
    {
        enemyAnim.IsAttacking = true;
        Debug.Log("Attack State Entered");
    }

    public void Tick()
    {

    }

    public void OnStateExit()
    {
        enemyAnim.IsAttacking = false;
        Debug.Log("Attack State Exitted");
    }

    public BarbarianAttackState(BarbarianAnimator anim)
    {
        enemyAnim = anim;
    }
}
