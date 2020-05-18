using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    protected Transform wallCheck;
    [SerializeField]
    protected Transform groundCheck;
    [SerializeField]
    protected float moveSpeed;

    [SerializeField]
    LayerMask flipLayerMask;

    public Rigidbody2D Body { get; private set; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    protected Enemy_Base enemy_Base;
    bool isFacingRight = true;

    const float ENEMY_FLIP_ANGLE_Y = 180f;
    const float WALL_CHECK_RAYCAST_OFFSET = 1.5f;
    const float GROUND_CHECK_RAYCAST_OFFSET = 0.5f;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        enemy_Base = GetComponent<Enemy_Base>();
    }

    public void MoveEnemy()
    {
        if (!enemy_Base.IsDead)
            Body.MovePosition(transform.position + transform.right * moveSpeed * TimeManager.deltaTime);
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FlipCharacter();
        }

        if (!enemy_Base.IsDead)
        {
            HandleWallCheck();
            HandleGroundCheck();
        }
    }

    public void FlipCharacter()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, ENEMY_FLIP_ANGLE_Y, 0f);
    }

    void HandleWallCheck()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(wallCheck.position, Vector2.right, WALL_CHECK_RAYCAST_OFFSET, flipLayerMask);

        if (hitInfo.collider != null)
        {
            FlipCharacter();
        }

    }
    void HandleGroundCheck()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, GROUND_CHECK_RAYCAST_OFFSET, flipLayerMask);

        if (hitInfo.collider == null)
        {
            FlipCharacter();
        }
    }
}
