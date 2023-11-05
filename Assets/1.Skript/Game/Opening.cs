using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Opening : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;

    // Text 배열로 변경
    [SerializeField] private Text[] texts;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (texts.Length > 0)
        {
            foreach (Text text in texts)
            {
                Color textColor = text.color;
                textColor.a = 0;
                text.color = textColor;
            }

            StartCoroutine(ShowTextsAndFadeIn());
        }
        else if (fadeOnStart)
        {
            FadeIn();
        }
    }

    private IEnumerator ShowTextsAndFadeIn()
    {
        foreach (Text text in texts)
        {
            // 모든 텍스트에 대해 코루틴 실행
            StartCoroutine(FadeText(text, 0, 1, fadeDuration));
        }

        // 모든 텍스트가 페이드 인되기를 기다립니다.
        yield return new WaitForSeconds(fadeDuration);

        FadeIn();

        // 페이드 아웃
        foreach (Text text in texts)
        {
            StartCoroutine(FadeText(text, 1, 0, fadeDuration));
        }

        yield return new WaitForSeconds(fadeDuration);

        this.gameObject.SetActive(false);
    }

    private IEnumerator FadeText(Text text, float alphaIn, float alphaOut, float duration)
    {
        float timer = 0;
        while (timer < duration)
        {
            float alpha = Mathf.Lerp(alphaIn, alphaOut, timer / duration);
            Color textColor = text.color;
            textColor.a = alpha;
            text.color = textColor;
            timer += Time.deltaTime;
            yield return null;
        }

        Color finalColor = text.color;
        finalColor.a = alphaOut;
        text.color = finalColor;
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
