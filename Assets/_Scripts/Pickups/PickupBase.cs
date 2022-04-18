using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBase : MonoBehaviour
{
    public float RotatingSpeed;
    public GameObject pickup;
    public PickupType type;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, RotatingSpeed, 0f) * Time.deltaTime);
    }
}

public enum PickupType
{
    Healing,
    Ammo
}
