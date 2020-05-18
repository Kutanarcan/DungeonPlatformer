using System;
using UnityEngine;

public class Demon : Enemy_Base
{
    [SerializeField]
    GameObject roarEffect;

    DemonAnimator demonAnimator;
    DemonMovement demonMovement;
    public bool IsDialogFinished;
    public bool IsAttackFinished { get; set; }

    public bool IsRoarFinished { get; set; }
    public AttackType AttackType { get; set; } 

    protected override void Awake()
    {
        base.Awake();
        demonAnimator = GetComponent<DemonAnimator>();
        demonMovement = GetComponent<DemonMovement>();
    }

    protected override void Start()
    {
        base.Start();
        InitializeStateMachine();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void InitializeStateMachine()
    {
        Transform roarPos = BossTracker.Instance.DemonTracker.GetRoarPos();
        Transform restPos = BossTracker.Instance.DemonTracker.GetRestPos();

        DemonIdleState demonIdleState = new DemonIdleState(demonAnimator);
        DemonFlyBeginPosState demonFlyBeginPosState = new DemonFlyBeginPosState(demonMovement, roarPos);
        DemonRoarState demonRoarState = new DemonRoarState(this, roarEffect, demonMovement);
        DemonChooseAttackState demonChooseAttackState = new DemonChooseAttackState(this);
        DemonChaseState demonChaseState = new DemonChaseState(this, demonMovement);
        DemonCloseAttackState demonCloseAttackState = new DemonCloseAttackState(this, demonAnimator);
        DemonRangedAttackState demonRangedAttackState = new DemonRangedAttackState(this, demonAnimator);
        DemonRestState demonRestState = new DemonRestState(demonMovement, restPos);
        DemonRetreatState demonRetreatState = new DemonRetreatState(demonMovement, roarPos);
        DemonDeathState demonDeathState = new DemonDeathState();

        stateMachine.AddTransition(demonIdleState, demonFlyBeginPosState, DialogFinished());//Idle To BeginPos
        stateMachine.AddTransition(demonFlyBeginPosState, demonRoarState, RoarPosReached());//BeginPos To Roar
        stateMachine.AddTransition(demonRoarState, demonChooseAttackState, RoarFinished());//Roar To ChooseAttack

        stateMachine.AddTransition(demonChooseAttackState, demonChaseState, CloseAttackChose());//ChooseAttack To Chase
        stateMachine.AddTransition(demonChaseState, demonCloseAttackState, TargetPointReached());//Chase To CloseAttack
        stateMachine.AddTransition(demonChooseAttackState, demonRangedAttackState, RangedAttackChose());//ChooseAttack To RangedAttack

        stateMachine.AddTransition(demonCloseAttackState, demonRestState, AttackFinished());//CloseAttack To Rest
        stateMachine.AddTransition(demonRangedAttackState, demonRestState, AttackFinished());//RangedAttack To Rest

        stateMachine.AddTransition(demonRestState, demonRetreatState, RestTimeOver());//Rest To Retreat
        stateMachine.AddTransition(demonRetreatState, demonChooseAttackState, RetreatPosReached());//Retreat To ChooseAttack

        stateMachine.AddAnyTransition(demonDeathState, HealthBelowZero());//Death State

        stateMachine.SetState(demonIdleState);

        Func<bool> DialogFinished() => () => IsDialogFinished;
        Func<bool> RoarPosReached() => () => Vector2.Distance(transform.position, roarPos.position) < 0.1f;
        Func<bool> RoarFinished() => () => demonRoarState.Timer > demonRoarState.RoarTime;
        Func<bool> CloseAttackChose() => () => AttackType == AttackType.CloseAttack;
        Func<bool> TargetPointReached() => () => Vector2.Distance(transform.position, Target.position) < 7f;
        Func<bool> RangedAttackChose() => () => AttackType == AttackType.RangedAttack;
        Func<bool> AttackFinished() => () => IsAttackFinished;
        Func<bool> RestTimeOver() => () => demonRestState.Timer > demonRestState.RestTime;
        Func<bool> RetreatPosReached() => () => Vector2.Distance(transform.position, roarPos.position) < 0.05f;
        Func<bool> HealthBelowZero() => () => IsDead;
    }

    public void HandleAttackFinished()
    {
        IsAttackFinished = true;
    }
}

public enum AttackType
{
    None,
    CloseAttack,
    RangedAttack
}
