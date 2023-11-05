using System.Collections.Generic;
using UnityEngine;

public class MoveSelectedObjects : MonoBehaviour
{
    public GameObject parentObject;
    public float rotationSpeed = 30f;

    void Update()
    {
        if (parentObject)
        {
            parentObject.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);                        
        }
    }
}