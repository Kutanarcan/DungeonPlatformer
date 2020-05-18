using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : Enemy_Base
{
    bool canReAttack;
    BarbarianAnimator barbarianAnimator;

    const float BARBARIAN_ATTACK_RANGE = 3f;
    const float BARBARIAN_RETURN_CHASE_RANGE = 5f;

    protected override void Awake()
    {
        base.Awake();
        barbarianAnimator = GetComponent<BarbarianAnimator>();
        InitializeStateMachine();
    }

    protected override void InitializeStateMachine()
    {
        BarbarianIdleState barbarianIdleState = new BarbarianIdleState(barbarianAnimator);
        BarbarianRunState barbarianRunState = new BarbarianRunState(barbarianAnimator, enemyMovement);
        BarbarianChaseState barbarianChaseState = new BarbarianChaseState(barbarianAnimator, enemyMovement, this);
        BarbarianAttackState barbarianAttackState = new BarbarianAttackState(barbarianAnimator);
        BarbarianDeathState barbarianDeathState = new BarbarianDeathState(barbarianAnimator);

        stateMachine.AddTransition(barbarianIdleState, barbarianRunState, SelectRandomTimeForIdleState()); //Idle To Run
        stateMachine.AddTransition(barbarianRunState, barbarianIdleState, SelectRandomTimeForRunState()); // Run To Idle

        stateMachine.AddTransition(barbarianIdleState, barbarianChaseState, HasTarget());//Idle To Chase
        stateMachine.AddTransition(barbarianRunState, barbarianChaseState, HasTarget());//Run To Chase
        stateMachine.AddTransition(barbarianChaseState, barbarianIdleState, HasNoTarget());//Chase To Idle
        stateMachine.AddTransition(barbarianAttackState, barbarianIdleState, HasNoTarget()); // Attack To Idle

        stateMachine.AddTransition(barbarianChaseState, barbarianAttackState, CanAttack()); //Chase To Attack
        stateMachine.AddTransition(barbarianAttackState, barbarianChaseState, ReturnChase()); // Attack To Chase

        stateMachine.AddAnyTransition(barbarianDeathState, IsDead());

        stateMachine.SetState(barbarianIdleState);

        Func<bool> SelectRandomTimeForIdleState() => () => barbarianIdleState.Timer > barbarianIdleState.IdleTime;
        Func<bool> SelectRandomTimeForRunState() => () => barbarianRunState.Timer > barbarianRunState.RunTime;
        Func<bool> HasTarget() => () => Target != null;
        Func<bool> HasNoTarget() => () => Target == null;
        Func<bool> CanAttack() => () => Target != null && Mathf.Abs(Target.position.x - transform.position.x) < BARBARIAN_ATTACK_RANGE;
        Func<bool> ReturnChase() => () => Target != null && (Mathf.Abs(Target.position.x - transform.position.x) > BARBARIAN_RETURN_CHASE_RANGE || canReAttack);
        Func<bool> IsDead() => () => health <= 0;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void EnableReAttack()
    {
        canReAttack = true;
    }

    public void DisableReAttack()
    {
        canReAttack = false;
    }
}