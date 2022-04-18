using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using StarterAssets;

public class UIBehaviour : MonoBehaviour
{
    public GameObject pauseMenu;
    public ThirdPersonController player;

    public AudioSource clickSound;

    public void onResumeClick()
    {
        clickSound.Play();

        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        player.isPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void onMainMenuClick()
    {
        clickSound.Play();
        SceneManager.LoadScene("MainMenuScene");
    }

    public void onRetryClick()
    {
        clickSound.Play();
        SceneManager.LoadScene("SampleScene");
    }
}
