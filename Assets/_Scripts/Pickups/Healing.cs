using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Healing : MonoBehaviour
{
    public ThirdPersonController player;
    public GameObject pickup;
    public bool cooldown;
    public float resetTime;
    public float RotatingSpeed;
    public PickupType type;

    private float timer;

    void Start()
    {
        timer = resetTime;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();

        if (cooldown)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                pickup.gameObject.SetActive(true);
                cooldown = false;
                timer = resetTime;
            }
        }
    }

    private void Rotate()
    {
        pickup.transform.Rotate(new Vector3(0f, RotatingSpeed, 0f) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player._health < player._maxHealth)
        {
            player._health = player._maxHealth;

            player.slider.SetHealth(player._health);

            pickup.gameObject.SetActive(false);

            cooldown = true;
        }
    }
}
