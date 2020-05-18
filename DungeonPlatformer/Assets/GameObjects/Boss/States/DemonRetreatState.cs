using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRetreatState : IState
{
    private DemonMovement demonMovement;
    private Transform roarPos;

    public void OnStateEnter()
    {
        Debug.Log("Retreat State Enter");
    }

    public void Tick()
    {
        demonMovement.MoveEnemy(roarPos);
    }

    public void OnStateExit()
    {
        Debug.Log("Retreat State Exit");
    }

    public DemonRetreatState(DemonMovement demonMovement, Transform roarPos)
    {
        this.demonMovement = demonMovement;
        this.roarPos = roarPos;
    }
}
