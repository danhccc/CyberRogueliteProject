using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public PlayerBehaviour pb;

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
        if (other.gameObject.CompareTag("Player") && !pb.isSpeedBoosting)
        {
            pb.isSpeedBoosting = true;
            pb.walkSpeed = 10;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            print("Starting boosting");
            StartCoroutine(BuffDuration());
        }
    }

    IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(3);
        print("End boosting");
        pb.isSpeedBoosting = false;
        pb.walkSpeed = 5;

        Destroy(this.gameObject);
    }
}
