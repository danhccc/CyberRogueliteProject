using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCountManager : MonoBehaviour
{
    public int killCount = 0;
    public TextMeshProUGUI CountText;

    public static KillCountManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            print("Hello???");
        }

        instance = this;
    }

    public void SetKillCount(int count)
    {
        killCount += count;
        CountText.text = killCount.ToString();
    }
}
