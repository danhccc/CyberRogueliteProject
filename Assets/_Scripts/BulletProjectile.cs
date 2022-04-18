using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRig;

    private void Awake()
    {
        bulletRig = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        float bSpeed = 50f;
        bulletRig.velocity = transform.forward * bSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Ammo")) || other.gameObject.CompareTag("Health"))
            return;

        Destroy(gameObject);
    }
}
