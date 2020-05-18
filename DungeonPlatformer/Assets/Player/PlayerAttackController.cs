using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Audio;
using System;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    SpecialAttackProfiles specialAttackProfiles;
    [SerializeField]
    Transform projectilePos;
    [SerializeField]
    GameObject bombPrefab;

    PlayerController playerController;
    AttackController attackController;
    Coroutine attackCoroutine;

    WaitForSeconds attackCooldown;

    public SpecialAttackProfiles SpecialAttackProfiles => specialAttackProfiles;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        attackController = GetComponentInChildren<AttackController>();
        attackCooldown = new WaitForSeconds(attackController.Cooldown);
    }

    public void Attack()
    {
        if (playerController.PlayerMovementController.IsGrounded && !playerController.PlayerAnimationController.IsAttacking)
        {
            attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }
    GameObject attackPrefab;

    public void SpecialAttack(InputType attackCode)
    {
        if (playerController.PlayerMovementController.IsGrounded && Mathf.Abs(playerController.PlayerMovementController.HorizontalAxis) <= 0.01)
        {
            attackPrefab = specialAttackProfiles.AttackDict[attackCode].gameObject;
            AudioManager.Instance.Play(specialAttackProfiles.SoundDict[attackCode], delay: 0.5f);
            playerController.PlayerAnimationController.SetIsProjectileAttackTrigger();
            playerController.PlayerMovementController.CanMove = false;
        }
    }

    public void SpawnBomb()
    {
        if (playerController.PlayerSkillController.SkillDict[SkillType.Bomb].activeness)
        {
            GameObject tmpObject = ObjectPooler.Instance.SpawnPoolObject(bombPrefab.name,transform.position,Quaternion.identity);
            ObjectPooler.Instance.ReturnToPool(bombPrefab.name, tmpObject, 5f);
        }
    }

    public void OnSpecialAttack()
    {
        GameObject tmpAttackPrefab;

        if (playerController.PlayerMovementController.IsFacingRight)
        {
            tmpAttackPrefab = ObjectPooler.Instance.SpawnPoolObject(attackPrefab.name, projectilePos.position, Quaternion.Euler(0, 0f, 0));
        }
        else
        {
            tmpAttackPrefab = ObjectPooler.Instance.SpawnPoolObject(attackPrefab.name, projectilePos.position, Quaternion.Euler(0, 180f, 0));
        }

        ObjectPooler.Instance.ReturnToPool(tmpAttackPrefab.name, tmpAttackPrefab, 3f);

        playerController.PlayerAnimationController.ResetIsProjectileAttackTrigger();
        playerController.PlayerMovementController.CanMove = true;
    }

    void StopAttackCoroutine()
    {
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    IEnumerator AttackCoroutine()
    {
        attackController.DoAttack();
        playerController.PlayerAnimationController.IsAttacking = true;
        yield return attackCooldown;
        playerController.PlayerAnimationController.IsAttacking = false;
    }

    public void ResetToDefaults()
    {
        StopAttackCoroutine();
        playerController.PlayerAnimationController.IsAttacking = false;
    }
}
