using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplayController : MonoBehaviour
{
    [SerializeField]
    Canvas healthBarCanvas;
    [SerializeField]
    Image healthBarContent;
    [SerializeField]
    TextMeshProUGUI healthText;

    HealthController healthController;
    Coroutine healthBarCoroutine;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        UpdateHealthBar();
    }

    public void ChangeCanvasScaleX(float rotationValue)
    {
        healthBarCanvas.transform.Rotate(0f, rotationValue, 0f);
    }

    public void UpdateHealthBar()
    {
        StopDecereaseHealthBarCoroutine();

        healthBarCoroutine = StartCoroutine(DecereaseHealthBarCoroutine());

        healthText.text = healthController.CurrentHealth.ToString();
    }

    void StopDecereaseHealthBarCoroutine()
    {
        if (healthBarCoroutine != null)
        {
            StopCoroutine(healthBarCoroutine);
            healthBarCoroutine = null;
        }
    }

    IEnumerator DecereaseHealthBarCoroutine()
    {
        float t = 0.0f;

        while (t <= 1.0f)
        {
            t += 0.5f * Time.deltaTime;
            healthBarContent.fillAmount = Mathf.Lerp(healthBarContent.fillAmount, healthController.CurrentHealth / healthController.MaxHealth, t);
            yield return null;
        }
    }
}
