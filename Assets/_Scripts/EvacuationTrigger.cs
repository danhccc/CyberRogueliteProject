using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class EvacuationTrigger : MonoBehaviour
{
    public GameObject gameoverScreen;
    public ThirdPersonController player;
    public TextMeshProUGUI WinLoseText;
    public TextMeshProUGUI finalCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.isPause = true;
            gameoverScreen.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            WinLoseText.text = "You Escaped";
            finalCount.text =KillCountManager.instance.killCount.ToString();
        }
    }
}
