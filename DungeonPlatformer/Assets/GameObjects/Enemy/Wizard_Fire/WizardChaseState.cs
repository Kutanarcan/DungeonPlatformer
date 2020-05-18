using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardChaseState : IState
{
    WizardAnimator enemyAnim;
    EnemyMovement enemyMovement;
    Wizard wizard;

    float movementSpeed;

    public void OnStateEnter()
    {
        enemyAnim.IsChasing = true;

        Debug.Log("Chase State Entered");
        enemyMovement.MoveSpeed = movementSpeed + movementSpeed / 2;
    }

    public void Tick()
    {
        enemyMovement.MoveEnemy();
    }

    public void OnStateExit()
    {
        enemyMovement.MoveSpeed = movementSpeed;

        enemyAnim.IsChasing = false;
        Debug.Log("Chase State Exitted");
    }

    public WizardChaseState(WizardAnimator anim, EnemyMovement movement, Wizard wizard)
    {
        enemyAnim = anim;
        enemyMovement = movement;
        movementSpeed = enemyMovement.MoveSpeed;
        this.wizard = wizard;
    }
}
