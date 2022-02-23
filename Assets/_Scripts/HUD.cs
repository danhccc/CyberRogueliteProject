using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image speedBoostIcon;
    public Image jumpBoostIcon;

    public PlayerBehaviour player;

    private Color hideIcon = new Color(255, 255, 255, 0);
    private Color showIcon = new Color(255, 255, 255, 255);

    // Start is called before the first frame update
    void Start()
    {
        speedBoostIcon.color = hideIcon;
        jumpBoostIcon.color = hideIcon;
    }   

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + player.health.ToString();

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

    public void ResetLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
