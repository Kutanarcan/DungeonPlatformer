using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;
    [SerializeField]
    Color warningColor;
    [SerializeField]
    Color normalColor;

    const float BOMB_TIME = 3F;
    const float FLICK_RATIO = 0.2F;
    Coroutine bombCoroutine;
    WaitForSeconds flickRatioWaitForSeconds;
    SpriteRenderer spriteRenderer;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        flickRatioWaitForSeconds = new WaitForSeconds(FLICK_RATIO);
    }

    IEnumerator BombCoroutine()
    {
        float bombTime = BOMB_TIME;
        float halfway = bombTime / 1.5f;

        while (bombTime > 0.1f)
        {
            bombTime -= Time.deltaTime;

            if (bombTime <= halfway)
            {
                spriteRenderer.color = warningColor;
                halfway = bombTime / 1.5f;
                yield return flickRatioWaitForSeconds;
                spriteRenderer.color = normalColor;
            }
            yield return null;
        }

        explosion.SetActive(true);
        spriteRenderer.enabled = false;
    }

    void OnEnable()
    {
        explosion.SetActive(false);
        spriteRenderer.enabled = true;
        bombCoroutine = StartCoroutine(BombCoroutine());
    }
}
