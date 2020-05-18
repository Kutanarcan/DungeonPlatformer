using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardRunState : IState
{
    public float RunTime { get; private set; }
    public float Timer { get; private set; }

    WizardAnimator enemyAnim;
    EnemyMovement enemyMovement;

    public void OnStateEnter()
    {
        Debug.Log("Run State Entered");
        enemyAnim.Speed = 1f;

        Timer = 0f;
        RunTime = Random.Range(5f, 10f);
        Debug.Log($"Run Time: {RunTime}");
    }

    public void Tick()
    {
        if (Timer < RunTime)
            Timer += Time.deltaTime;

        enemyMovement.MoveEnemy();
    }

    public void OnStateExit()
    {
        Debug.Log("Run State Exitted");
    }

    public WizardRunState(WizardAnimator anim, EnemyMovement movement)
    {
        enemyAnim = anim;
        enemyMovement = movement;
    }
}
