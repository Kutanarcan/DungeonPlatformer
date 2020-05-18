using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator anim;

    static int paramSpeed = Animator.StringToHash("Speed");
    static int paramIsAttacking = Animator.StringToHash("IsAttacking");
    static int paramIsGrounded = Animator.StringToHash("IsGrounded");
    static int paramIsJumping= Animator.StringToHash("IsJumping");
    static int paramIsProjectileAttack = Animator.StringToHash("IsProjectileAttack");
    static int paramIsDamaged = Animator.StringToHash("IsDamaged");
    static int paramIsDead = Animator.StringToHash("IsDead");
    static int paramIsWallSliding = Animator.StringToHash("IsWallSliding");
    static int paramIsLanding = Animator.StringToHash("IsLanding");

    public float Speed
    {
        get => anim.GetFloat(paramSpeed);

        set
        {
            anim.SetFloat(paramSpeed, value);
        }
    }

    public bool IsAttacking
    {
        get => anim.GetBool(paramIsAttacking);

        set
        {
            anim.SetBool(paramIsAttacking, value);
        }
    }

    public bool IsLanding
    {
        get => anim.GetBool(paramIsLanding);

        set
        {
            anim.SetBool(paramIsLanding, value);
        }
    }

    public bool IsWallSliding
    {
        get => anim.GetBool(paramIsWallSliding);

        set
        {
            anim.SetBool(paramIsWallSliding, value);
        }
    }

    public bool IsGrounded
    {
        get => anim.GetBool(paramIsGrounded);

        set
        {
            anim.SetBool(paramIsGrounded,value);
        }
    }

    public bool IsJumping
    {
        get => anim.GetBool(paramIsJumping);

        set
        {
            anim.SetBool(paramIsJumping, value);
        }
    }

    public void SetIsProjectileAttackTrigger()
    {
        anim.SetTrigger(paramIsProjectileAttack);
    }

    public void ResetIsProjectileAttackTrigger()
    {
        anim.ResetTrigger(paramIsProjectileAttack);
    }

    public void SetIsDamagedTrigger()
    {
        anim.SetTrigger(paramIsDamaged);
    }

    public void ResetIsDamagedTrigger()
    {
        anim.ResetTrigger(paramIsDamaged);
    }
    
    public void SetIsDeadTrigger()
    {
        anim.SetTrigger(paramIsDead);
    }

    public void ResetIsDeadTrigger()
    {
        anim.ResetTrigger(paramIsDead);
    }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
}
