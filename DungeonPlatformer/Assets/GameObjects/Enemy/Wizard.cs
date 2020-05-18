using System;
using UnityEngine;

public class Wizard : Enemy_Base
{
    WizardAnimator wizardAnimator;
    WizardAttackController wizardAttackController;

    const float WIZARD_ATTACK_RANGE = 15f;
    const float WIZARD_RETURN_CHASE_RANGE = 21f;

    protected override void Awake()
    {
        base.Awake();
        wizardAnimator = GetComponent<WizardAnimator>();
        wizardAttackController = GetComponent<WizardAttackController>();
        InitializeStateMachine();
    }

    protected override void InitializeStateMachine()
    {
        WizardIdleState wizardIdleState = new WizardIdleState(wizardAnimator);
        WizardRunState wizardRunState = new WizardRunState(wizardAnimator, enemyMovement);
        WizardChaseState wizardChaseState = new WizardChaseState(wizardAnimator, enemyMovement, this);
        WizardAttackState wizardAttackState = new WizardAttackState(wizardAnimator, wizardAttackController);
        WizardDeathState wizardDeathState = new WizardDeathState(wizardAnimator);

        stateMachine.AddTransition(wizardIdleState, wizardRunState, SelectRandomTimeForIdleState()); //Idle To Run
        stateMachine.AddTransition(wizardRunState, wizardIdleState, SelectRandomTimeForRunState()); // Run To Idle

        stateMachine.AddTransition(wizardIdleState, wizardChaseState, HasTarget());//Idle To Chase
        stateMachine.AddTransition(wizardRunState, wizardChaseState, HasTarget());//Run To Chase
        stateMachine.AddTransition(wizardChaseState, wizardIdleState, HasNoTarget());//Chase To Idle
        stateMachine.AddTransition(wizardAttackState, wizardIdleState, HasNoTarget()); // Attack To Idle

        stateMachine.AddTransition(wizardChaseState, wizardAttackState, CanAttack()); //Chase To Attack
        stateMachine.AddTransition(wizardAttackState, wizardChaseState, ReturnChase()); // Attack To Chase

        stateMachine.AddAnyTransition(wizardDeathState, IsDead());

        stateMachine.SetState(wizardIdleState);

        Func<bool> SelectRandomTimeForIdleState() => () => wizardIdleState.Timer > wizardIdleState.IdleTime;
        Func<bool> SelectRandomTimeForRunState() => () => wizardRunState.Timer > wizardRunState.RunTime;
        Func<bool> HasTarget() => () => Target != null;
        Func<bool> HasNoTarget() => () => Target == null;
        Func<bool> CanAttack() => () => Target != null && Mathf.Abs(Target.position.x - transform.position.x) < WIZARD_ATTACK_RANGE;
        Func<bool> ReturnChase() => () => Target != null && (Mathf.Abs(Target.position.x - transform.position.x) > WIZARD_RETURN_CHASE_RANGE);
        Func<bool> IsDead() => () => health <= 0;
    }

    protected override void Update()
    {
        base.Update();
    }
}