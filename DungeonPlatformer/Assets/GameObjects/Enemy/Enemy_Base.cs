using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy_Base : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected float health;
    [SerializeField]
    Color flashColor;

    public Transform Target { get; set; }
    public bool IsDead => health <= 0;

    protected EnemyMovement enemyMovement;
    protected StateMachine stateMachine;

    SpriteRenderer spriteRenderer;
    Color defaultColor;

    WaitForSeconds flashSeconds;
    Coroutine flashCoroutine;

    const float FLASH_WAIT_TIME = 0.2f;

    protected virtual void Awake()
    {
        flashSeconds = new WaitForSeconds(FLASH_WAIT_TIME);
        defaultColor = new Color(255, 255, 255, 255);

        stateMachine = new StateMachine();
        enemyMovement = GetComponent<EnemyMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        Collider2D playerCollider = PlayerController.Instance.gameObject.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, true);
    }

    protected virtual void Update()
    {
        stateMachine.Tick();
    }

    public void TakeDamage(float damageAmount)
    {
        if (health > 0)
        {
            if (Target==null)
            {
                Target = PlayerController.Instance.gameObject.transform;
                enemyMovement.FlipCharacter();
            }

            health -= damageAmount;
            flashCoroutine = StartCoroutine(FlashCoroutine());
        }
    }

    protected abstract void InitializeStateMachine();

    IEnumerator FlashCoroutine()
    {
        spriteRenderer.color = flashColor;
        yield return flashSeconds;
        spriteRenderer.color = defaultColor;
    }
}