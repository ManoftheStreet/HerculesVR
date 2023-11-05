using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    [SerializeField] private UnityEngine.UI.Image logo;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (logo != null)
        {
            Color logoColor = logo.color;
            logoColor.a = 0;
            logo.color = logoColor;

            StartCoroutine(ShowLogoAndFadeIn());
        }

        else if (fadeOnStart)
        {
            FadeIn();
        }
    }

    private IEnumerator ShowLogoAndFadeIn()
    {
        yield return StartCoroutine(FadeLogo(0, 1, 2));

        yield return new WaitForSeconds(2);

        FadeIn();

        yield return StartCoroutine(FadeLogo(1, 0, 2));

        this.gameObject.SetActive(false);
    }

    private IEnumerator FadeLogo(float alphaIn, float alphaOut, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            float alpha = Mathf.Lerp(alphaIn, alphaOut, timer / duration);
            Color logoColor = logo.color;
            logoColor.a = alpha;
            logo.color = logoColor;
            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = logo.color;
        finalColor.a = alphaOut;
        logo.color = finalColor;
    }

    public void FadeIn()
    {
        Fade(1, 0);        
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            if (rend != null)
            {
                Color newColor = fadeColor;
                newColor.a = alpha;
                rend.material.SetColor("_Color", newColor);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        if (rend != null)
        {
            Color newColor2 = fadeColor;
            newColor2.a = alphaOut;
            rend.material.SetColor("_Color", newColor2);
        }
    }
}
