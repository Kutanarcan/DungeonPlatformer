using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonChooseAttackState : IState
{
    Demon demon;

    public void OnStateEnter()
    {
        int rand = Random.Range(0, 100);

        if (rand < 50)
        {
            demon.AttackType = AttackType.CloseAttack;
        }
        else if (rand >= 50)
        {
            demon.AttackType = AttackType.RangedAttack;
        }
    }

    public void Tick()
    {
        Debug.Log("Choose State Tick");
    }

    public void OnStateExit()
    {
        Debug.Log("Choose State Exit");
    }

    public DemonChooseAttackState(Demon demon)
    {
        this.demon = demon;
    }
}
