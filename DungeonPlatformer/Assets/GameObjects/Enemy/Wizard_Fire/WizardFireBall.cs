using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardFireBall : MonoBehaviour, IDamageable
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float damageAmount;

    Rigidbody2D body;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        body.MovePosition(transform.position + transform.right * moveSpeed * TimeManager.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            PlayerDamageController playerDamageController = other.GetComponent<PlayerDamageController>();
            playerDamageController.TakeDamage(damageAmount);

            ObjectPooler.Instance.ReturnToPool(gameObject.name, gameObject);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        ObjectPooler.Instance.ReturnToPool(gameObject.name, gameObject);
    }
}
