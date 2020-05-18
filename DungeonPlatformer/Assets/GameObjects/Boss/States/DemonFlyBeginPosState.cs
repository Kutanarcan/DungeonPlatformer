using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFlyBeginPosState : IState
{
    DemonMovement demonMovement;
    Transform beginPos;

    public void OnStateEnter()
    {
        demonMovement.HandleMoveDirection(beginPos);
        Debug.Log("Demon BeginPos State Enter");
    }

    public void Tick()
    {
        demonMovement.MoveEnemy(beginPos);
    }

    public void OnStateExit()
    {
        Debug.Log("BeginPos State Exit");
    }

    public DemonFlyBeginPosState(DemonMovement demonMovement, Transform beginPos)
    {
        this.demonMovement = demonMovement;
        this.beginPos = beginPos;
    }
}
