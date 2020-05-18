using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChaseState : IState
{
    Demon demon;
    DemonMovement demonMovement;

    Transform target;

    public void OnStateEnter()
    {
        demon.IsAttackFinished = false;
        target = demon.Target;
        demonMovement.HandleMoveDirection(target);
        Debug.Log("Chase State Enter");
    }

    public void Tick()
    {
        demonMovement.MoveEnemy(target);
    }

    public void OnStateExit()
    {
        Debug.Log("Chase State Exit");
    }

    public DemonChaseState(Demon demon, DemonMovement demonMovement)
    {
        this.demon = demon;
        this.demonMovement = demonMovement;
    }
}
