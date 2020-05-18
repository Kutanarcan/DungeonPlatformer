using UnityEngine;

public class BarbarianChaseState : IState
{
    BarbarianAnimator enemyAnim;
    EnemyMovement enemyMovement;
    Barbarian barbarian;

    float movementSpeed;

    public void OnStateEnter()
    {
        barbarian.DisableReAttack();
        enemyAnim.IsChasing = true;

        Debug.Log("Chase State Entered");
        enemyMovement.MoveSpeed = movementSpeed + movementSpeed / 2;
    }

    public void Tick()
    {
        enemyMovement.MoveEnemy();
    }

    public void OnStateExit()
    {
        enemyMovement.MoveSpeed = movementSpeed;

        enemyAnim.IsChasing = false;
        Debug.Log("Chase State Exitted");
    }

    public BarbarianChaseState(BarbarianAnimator anim, EnemyMovement movement, Barbarian barbarian)
    {
        enemyAnim = anim;
        enemyMovement = movement;
        movementSpeed = enemyMovement.MoveSpeed;
        this.barbarian = barbarian;
    }
}
