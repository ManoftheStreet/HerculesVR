using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFade : MonoBehaviour
{
    public GameObject quad; // Quad 오브젝트를 여기에 할당합니다.
    public float fadeDuration = 1.0f; // 페이드 인 지속 시간 (초)

    bool isFading = false;
    float currentAlpha = 0.0f;
    Material quadMaterial;
    Color originalColor;

    void Start()
    {
        // Quad 오브젝트의 Material 및 원래 색상을 가져옵니다.
        quadMaterial = quad.GetComponent<Renderer>().material;
        originalColor = quadMaterial.color;
    }

    void Update()
    {
        if (isFading)
        {
            // 페이드 인 중이라면 알파값을 서서히 증가시킵니다.
            currentAlpha += Time.deltaTime / fadeDuration;
            Color newColor = quadMaterial.color;
            newColor.a = Mathf.Clamp01(currentAlpha);
            quadMaterial.color = newColor;

            if (currentAlpha >= 1.0f)
            {
                // 페이드 인이 완료되면 플래그를 리셋합니다.
                isFading = false;
            }
        }
    }

    public void OnQuadClick()
    {
        if (!isFading)
        {
            // 클릭 시 페이드 인 애니메이션을 시작합니다.
            currentAlpha = 0.0f;
            isFading = true;
        }
    }
}
