using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class JumpBoost : MonoBehaviour
{
    public PlayerBehaviour pb;
    public ThirdPersonController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.isJumpBoosting = true;
            player.JumpHeight = 5f;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            print("Starting boosting");
            StartCoroutine(BuffDuration());
            StartCoroutine(ResetTimer());
        }
    }

    IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(10);
        print("End boosting");
        player.isJumpBoosting = false;
        player.JumpHeight = 1.2f;

        this.gameObject.SetActive(false);
    }

    IEnumerator ResetTimer()
    {
        yield return new WaitForSeconds(15);
        this.gameObject.SetActive(true);
    }
}
