using System.Collections;
using UnityEngine;

public class Observatory : MonoBehaviour
{
    public GameObject parentObject;
    public float rotationSpeed = 30f;

    private float currentSpeedMultiplier = 1f;
    private bool isButtonPressed = false;
    private float buttonPressTime = 0f;
    private float baseMultiplier = 1f;

    void Update()
    {
        if (parentObject)
        {
            parentObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * currentSpeedMultiplier * baseMultiplier);

            if (isButtonPressed)
            {
                buttonPressTime += Time.deltaTime;

                if (buttonPressTime >= 3f)
                {
                    currentSpeedMultiplier = 10f;
                }
                else
                {
                    currentSpeedMultiplier = 3f;
                }
            }
            else
            {
                currentSpeedMultiplier = 1f;
                buttonPressTime = 0f;
            }
        }
    }

    public void OnArrowButtonPressed(bool isRight)
    {
        isButtonPressed = true;
        baseMultiplier = isRight ? 1f : -1f;
    }

    public void OnArrowButtonReleased()
    {
        isButtonPressed = false;
        buttonPressTime = 0f;
        currentSpeedMultiplier = 1f;
    }

    public void ResetRotationSpeed()
    {
        isButtonPressed = false;
        buttonPressTime = 0f;
        currentSpeedMultiplier = 1f;
        baseMultiplier = 1f;
    }
}
