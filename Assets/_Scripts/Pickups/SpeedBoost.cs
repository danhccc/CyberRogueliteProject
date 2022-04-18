using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SpeedBoost : MonoBehaviour
{
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
        if (other.gameObject.CompareTag("Player") && !player.isSpeedBoosting)
        {
            player.isSpeedBoosting = true;
            player.SprintSpeed *= 2;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            print("Starting boosting");
            StartCoroutine(BuffDuration());
        }
    }

    IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(10);
        print("End boosting");
        player.isSpeedBoosting = false;
        player.SprintSpeed /= 2;

        Destroy(this.gameObject);
    }
}
