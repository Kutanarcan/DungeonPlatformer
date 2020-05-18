using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAnimator : MonoBehaviour
{
    [SerializeField]
    protected Animator anim;

    static int paramSpeed = Animator.StringToHash("Speed");
    static int paramDead = Animator.StringToHash("Dead");
    static int paramChase = Animator.StringToHash("Chase");
    protected static int paramAttack = Animator.StringToHash("Attack");

    public float Speed
    {
        get => anim.GetFloat(paramSpeed);        
            
        set => anim.SetFloat(paramSpeed, value);       
    }

    public bool IsChasing
    {
        get => anim.GetBool(paramChase);

        set => anim.SetBool(paramChase, value);
    }

    public bool IsAttacking
    {
        get => anim.GetBool(paramAttack);

        set => anim.SetBool(paramAttack, value);
    }

    public void SetDeadTrigger()
    {
        anim.SetTrigger(paramDead);
    }

    public void ResetDeadTrigger()
    {
        anim.ResetTrigger(paramDead);
    }
}
