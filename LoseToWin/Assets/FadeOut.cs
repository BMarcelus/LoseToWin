using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public int fadeOutRate;

    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeOutCoroutine()
    {
        // start fading
        yield return StartCoroutine(FadeInFadeOut.FadeCanvas(canvasGroup, 1f, 0f, fadeOutRate));
        gameObject.SetActive(false);
    }
}
