using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttackState : IState
{
    WizardAnimator enemyAnim;
    WizardAttackController wizardAttackController;

    float reAttackTimer;

    const float RE_ATTACK_TIME = 2f;
    public void OnStateEnter()
    {

        enemyAnim.IsAttacking = true;
    }

    public void Tick()
    {
        if (reAttackTimer >= RE_ATTACK_TIME)
        {
            enemyAnim.PlayAttackAnimation();
            reAttackTimer = 0;
        }
        else
        {
            reAttackTimer += Time.deltaTime;
        }
    }

    public void OnStateExit()
    {
        enemyAnim.IsAttacking = false;
    }

    public WizardAttackState(WizardAnimator anim, WizardAttackController wizardAttackController)
    {
        enemyAnim = anim;
        this.wizardAttackController = wizardAttackController;
    }
}
