using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimator : EnemyAnimator
{
    const string WIZARD_ATTACK_CLIP_NAME = "WizardAttack";

    public void PlayAttackAnimation()
    {
        anim.Play(WIZARD_ATTACK_CLIP_NAME, -1, 0);
    }
}
