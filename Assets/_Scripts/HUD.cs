using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;

public class HUD : MonoBehaviour
{
    public ThirdPersonController player;

    public Image speedBoostIcon;
    public Image jumpBoostIcon;


    private Color hideIcon = new Color(255, 255, 255, 0);
    private Color showIcon = new Color(255, 255, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        speedBoostIcon.color = hideIcon;
        jumpBoostIcon.color = hideIcon;
        Time.timeScale = 1;
    }   

    // Update is called once per frame
    void Update()
    {

        if (player.isSpeedBoosting)
        {
            speedBoostIcon.color = showIcon;
        }
        else
        {
            speedBoostIcon.color = hideIcon;
        }

        if (player.isJumpBoosting)
        {
            jumpBoostIcon.color = showIcon;
        }
        else
        {
            jumpBoostIcon.color = hideIcon;
        }
    }

}
