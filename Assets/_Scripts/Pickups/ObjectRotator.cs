using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public float RotatingSpeed;
    void Update()
    {
        transform.Rotate(new Vector3(0f, RotatingSpeed, 0f) * Time.deltaTime);
    }
}
