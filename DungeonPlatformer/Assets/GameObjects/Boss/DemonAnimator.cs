using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonAnimator : MonoBehaviour
{
    [SerializeField]
    protected Animator anim;

    static int paramFly = Animator.StringToHash("Fly");
    static int paramCloseAttack = Animator.StringToHash("CloseAttack");
    static int paramRangedAttack = Animator.StringToHash("RangedAttack");
    static int paramDeath = Animator.StringToHash("Death");

    public bool IsFlying
    {
        get => anim.GetBool(paramFly);

        set => anim.SetBool(paramFly, value);
    }

    public void SetCloseAttackTrigger()
    {
        anim.SetTrigger(paramCloseAttack);
    }

    public void ResetCloseAttackTrigger()
    {
        anim.ResetTrigger(paramCloseAttack);
    }

    public void SetRangedAttackTrigger()
    {
        anim.SetTrigger(paramRangedAttack);
    }

    public void ResetRangedAttackTrigger()
    {
        anim.ResetTrigger(paramRangedAttack);
    }

    public void SetDeathTrigger()
    {
        anim.SetTrigger(paramDeath);
    }

    public void ResetDeathTrigger()
    {
        anim.ResetTrigger(paramDeath);
    }
}
