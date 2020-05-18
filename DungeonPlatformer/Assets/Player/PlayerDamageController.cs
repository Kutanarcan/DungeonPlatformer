using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageController : MonoBehaviour, IBombTarget
{
    PlayerController playerController;

    public bool IsDead { get; set; }
    Collider2D playerCollider;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerCollider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        PlayerEvents.OnPlayerTakeDamage += TakeDamage;
        playerCollider.enabled = true;
        playerController.PlayerMovementController.Body.gravityScale = 2;
    }

    public void TakeDamage(float damageAmount)
    {
        if (playerController.HealthController.CurrentHealth > 0)
        {
            playerController.PlayerAnimationController.SetIsDamagedTrigger();

            playerController.HealthController.CurrentHealth -= damageAmount;
            playerController.HealthDisplayController.UpdateHealthBar();
        }

        if (playerController.HealthController.CurrentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        IsDead = true;
        playerController.PlayerAttackController.enabled = false;
        playerController.PlayerInputController.enabled = false;
        playerController.PlayerMovementController.enabled = false;
        playerController.PlayerAnimationController.SetIsDeadTrigger();

        PlayerEvents.OnPlayerDiedFunction();
        playerCollider.enabled = false;
        playerController.PlayerMovementController.Body.gravityScale = 0;
        //Do Death Things
    }

    void OnDisable()
    {
        PlayerEvents.OnPlayerTakeDamage -= TakeDamage;
    }

    public void DamageWithBomb(float damageAmount)
    {
        TakeDamage(damageAmount);
    }
}
