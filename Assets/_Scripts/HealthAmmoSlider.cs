using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;
using TMPro;

public class HealthAmmoSlider : MonoBehaviour
{

    public Slider healthSlider;
    public Slider ammoSlider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        healthText.text = health.ToString();
    }

    public void SetAmmo(int ammo)
    {
        ammoSlider.value = ammo;
        ammoText.text = ammo.ToString();
    }
}
