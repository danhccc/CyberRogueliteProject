using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class EvacuateTimer : MonoBehaviour
{
    public float timer;
    public ThirdPersonController player;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI evacuationText;

    public GameObject evacuationPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPause)
            return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F1");
        }
        else if (timer <= 0.0f)
        {
            timerText.text = "";
            evacuationText.text = "Evacuation Available";
            evacuationPoint.SetActive(true);
        }
    }
}
