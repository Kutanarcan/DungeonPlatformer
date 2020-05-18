using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpForceValue;
    [SerializeField]
    float wallSlidingSpeed;
    [SerializeField]
    float wallJumpForce;
    [SerializeField]
    Transform groundCheckPoint;   
    [SerializeField]
    Transform wallCheckPoint;
    [SerializeField]
    LayerMask groundCheckLayer;


    public Rigidbody2D Body { get; set; }
    public float HorizontalAxis { get; set; }
    public bool IsGrounded { get; set; }
    public bool CanMove { get; set; }
    public bool IsTouchingWall { get; set; }
    public bool IsWallSliding { get; set; }
    public bool IsLanding { get; set; }
    public bool IsOnMovingPlatform { get; set; }

    Vector2 moveVector => new Vector2(HorizontalAxis * moveSpeed * TimeManager.fixedDeltaTime, Body.velocity.y);
    Vector2 jumpVector => new Vector2(0, jumpForceValue);
    Vector2 wallSlidingVector => new Vector2(Body.velocity.x, -wallSlidingSpeed);

    public bool IsFacingRight => isFacingRight;

    PlayerController playerController;

    public bool isFacingRight = false;
    private bool isFirstTouchGround;
    const float PLAYER_FLIP_ANGLE_Y = 180f;
    const float PLAYER_GROUND_CHECK_RAYCAST_OFFSET_Y = 0.5f;
    const float PLAYER_GROUND_CHECK_RAYCAST_OFFSET_XY = 0.75f;
    const float PLAYER_Wall_CHECK_RAYCAST_OFFSET_x = 0.8f;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        ResetToDefaults();
    }

    void FixedUpdate()
    {
        if (CanMove)
        {
            HandleMovement();
            CalculateWallJump();
        }
    }

    void LateUpdate()
    {
        if (CanMove)
        {
            HandleIsGrounded();
            HandleIsLanding();
            HandleMovementDirection();
        }
    }

    void HandleMovement()
    {
        if (!IsWallSliding)
        {
            playerController.PlayerAnimationController.Speed = Mathf.Abs(HorizontalAxis);
            Body.velocity = moveVector;
        }

        if (IsWallSliding && Body.velocity.y < -wallSlidingSpeed)
        {
            Body.velocity = wallSlidingVector;
        }
    }

    void HandleMovementDirection()
    {
        if (!IsWallSliding)
        {
            if (HorizontalAxis > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (HorizontalAxis < 0 && isFacingRight)
            {
                FlipCharacter();
            }
        }
    }

    public void HandleJump()
    {
        if (IsGrounded)
        {
            playerController.PlayerAnimationController.IsJumping = true;
            Body.AddForce(jumpVector);
            playerController.PlayerAttackController.ResetToDefaults();
            AudioManager.Instance.Play(MyAudioType.Player_Jump);
        }

        if (IsWallSliding)
        {
            AudioManager.Instance.Play(MyAudioType.Player_Jump);
            HandleWallJump();
        }
    }

    void FlipCharacter()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, PLAYER_FLIP_ANGLE_Y, 0f);
        playerController.HealthDisplayController.ChangeCanvasScaleX(PLAYER_FLIP_ANGLE_Y);
    }

    void HandleIsGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, PLAYER_GROUND_CHECK_RAYCAST_OFFSET_Y, groundCheckLayer);

        if (hitInfo.collider != null)
        {
            playerController.PlayerAnimationController.IsJumping = false;
            IsGrounded = true;
            IsLanding = false;

            if (isFirstTouchGround)
            {
                isFirstTouchGround = false;
                AudioManager.Instance.Play(MyAudioType.Player_Land);
                //Partical Effect (Dust on Feet)
            }
        }
        else
        {
            isFirstTouchGround = true;
            IsGrounded = false;
        }

        playerController.PlayerAnimationController.IsGrounded = IsGrounded;
    }

    void HandleIsLanding()
    {
        if (Body.velocity.y < 0 && !IsOnMovingPlatform)
        {
            IsLanding = true;
        }

        playerController.PlayerAnimationController.IsLanding = IsLanding;
    }

    void HandleWallJump()
    {
        if (playerController.PlayerSkillController.SkillDict[SkillType.WallJump].activeness)
        {
            if (IsFacingRight && HorizontalAxis < 0f)
            {
                Body.AddForce(Vector2.one * wallJumpForce, ForceMode2D.Impulse);
            }
            else if (!IsFacingRight && HorizontalAxis > 0f)
            {
                Body.AddForce(Vector2.one * wallJumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public void PlayWalkEffects()
    {
        AudioManager.Instance.Play(MyAudioType.Player_Walk);
        //Do Smoke partical effect
    }

    void CalculateWallJump()
    {
        if (playerController.PlayerSkillController.SkillDict[SkillType.WallJump].activeness)
        {
            IsTouchingWall = Physics2D.Raycast(wallCheckPoint.position, -transform.right, PLAYER_Wall_CHECK_RAYCAST_OFFSET_x, groundCheckLayer);
            playerController.PlayerAnimationController.IsWallSliding = IsTouchingWall;

            IsWallSliding = (IsTouchingWall && !IsGrounded && Body.velocity.y < 0) ? true : false;
        }
    }

    public void ResetToDefaults()
    {
        CanMove = true;
        IsOnMovingPlatform = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(wallCheckPoint.position, new Vector3(wallCheckPoint.position.x + PLAYER_Wall_CHECK_RAYCAST_OFFSET_x, wallCheckPoint.position.y, wallCheckPoint.position.z));
    }
}
