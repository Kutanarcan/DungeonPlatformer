using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonRestState : IState
{
    DemonMovement demonMovement;
    Transform restPos;

    public float RestTime { get; private set; } = 5f;
    public float Timer { get; private set; }

    public void OnStateEnter()
    {
        demonMovement.HandleMoveDirection(restPos);
        Timer = 0;
    }

    public void Tick()
    {
        Debug.Log($"Distance Between Demon and Rest Pos : {Vector2.Distance(demonMovement.gameObject.transform.position, restPos.position)}");
        if (Vector2.Distance(demonMovement.gameObject.transform.position, restPos.position) > 0.1f)
        {
            demonMovement.MoveEnemy(restPos);
        }
        else if (Vector2.Distance(demonMovement.gameObject.transform.position, restPos.position) <= 0.2f)
        {
            if (Timer < RestTime)
                Timer += TimeManager.deltaTime;
        }
    }

    public void OnStateExit()
    {
        Debug.Log("Rest State Exit");
    }

    public DemonRestState(DemonMovement demonMovement, Transform restPos)
    {
        this.demonMovement = demonMovement;
        this.restPos = restPos;
    }
}
