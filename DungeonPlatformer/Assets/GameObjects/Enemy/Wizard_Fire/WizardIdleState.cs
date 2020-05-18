using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardIdleState : IState
{
    public float IdleTime { get; private set; }
    public float Timer { get; private set; }

    WizardAnimator enemyAnim;

    public void OnStateEnter()
    {
        Debug.Log("Idle State Entered");
        enemyAnim.Speed = 0f;

        Timer = 0f;
        IdleTime = Random.Range(1f, 4f);
        Debug.Log($"Idle Time: {IdleTime}");
    }

    public void Tick()
    {
        if (Timer < IdleTime)
            Timer += Time.deltaTime;
    }

    public void OnStateExit()
    {
        Debug.Log("Idle State Exitted");
    }

    public WizardIdleState(WizardAnimator anim)
    {
        enemyAnim = anim;
    }
}
