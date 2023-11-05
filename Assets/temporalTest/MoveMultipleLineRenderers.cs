using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMultipleLineRenderers : MonoBehaviour
{
    public List<LineRenderer> lineRenderers;
    public float speed = 0.1f;
    public float period = 1f;

    void Start()
    {
        lineRenderers = new List<LineRenderer>(FindObjectsOfType<LineRenderer>());
    }

    void Update()
    {
        float time = Time.time;

        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            int pointCount = lineRenderer.positionCount;
            for (int i = 0; i < pointCount; i++)
            {
                Vector3 originalPos = lineRenderer.GetPosition(i);
                float offsetX = Mathf.Sin(time * period + i) * speed;
                float offsetY = Mathf.Cos(time * period + i) * speed;
                Vector3 newPos = new Vector3(originalPos.x + offsetX, originalPos.y + offsetY, originalPos.z);
                lineRenderer.SetPosition(i, newPos);
            }
        }
    }
}