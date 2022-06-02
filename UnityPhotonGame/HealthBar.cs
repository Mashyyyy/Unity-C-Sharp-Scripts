using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image healthBarImage;
    [SerializeField]
    private float updateSpeed = 0.5f;

    private void Awake()
    {
        GetComponentInParent<Health>().onHealthPctChanged += HandleHealthChange;
    }

    private void HandleHealthChange(float hpPct)
    {
        StartCoroutine(ChangeToPct(hpPct));
    }
    private IEnumerator ChangeToPct(float pct)
    {
        float preChangePct = healthBarImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeed)
        {
            elapsed += Time.deltaTime;
            healthBarImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeed);
            yield return null;
        }

        healthBarImage.fillAmount = pct;
    }


    void LateUpdate()
    {
        /*
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        */
    }
}