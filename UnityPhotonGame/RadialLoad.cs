using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialLoad : MonoBehaviour
{
    [SerializeField]
    private float cooldownTime = 0.5f;
    public Image radialLoad;

    private void OnEnable()
    {
        radialLoad.fillAmount = 1f;
        StartCoroutine(loadRadial(cooldownTime));
    }

    IEnumerator loadRadial(float duration)
    {
        float startTime = Time.time;
        float time = duration;
        float value = 0;

        while(Time.time - startTime < duration)
        {
            time -= Time.deltaTime;
            value = time / cooldownTime;
            radialLoad.fillAmount = value;
            yield return null;
        }

        this.gameObject.SetActive(false);
        GetComponentInParent<Button>().interactable = true;
    }
}