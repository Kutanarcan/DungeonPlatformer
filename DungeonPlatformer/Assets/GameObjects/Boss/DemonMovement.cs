using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : EnemyMovement
{
    protected override void Update()
    {

    }

    public void MoveEnemy(Transform movePos)
    {
        if (!enemy_Base.IsDead)
        {
            transform.position = Vector2.MoveTowards(transform.position, movePos.position, moveSpeed * TimeManager.deltaTime);
        }
    }

    public void HandleMoveDirection(Transform directionPos)
    {
        Vector3 dir = directionPos.position - transform.position;
        dir = directionPos.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (angle < 0)
            angle += 180f;

        if (dir.x > 0f)
            transform.Rotate(0f, 180f, angle);
        else
            transform.Rotate(0f, 0f, angle);
    }

    public void ResetDirection()
    {
        transform.rotation = Quaternion.identity;
    }
}
