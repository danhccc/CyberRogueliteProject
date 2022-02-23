using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            pb.isJumpBoosting = true;
            pb.jumpForce = 10;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            print("Starting boosting");
            StartCoroutine(BuffDuration());
        }
    }

    IEnumerator BuffDuration()
    {
        yield return new WaitForSeconds(5);
        print("End boosting");
        pb.isJumpBoosting = false;
        pb.jumpForce = 5;

        Destroy(this.gameObject);
    }
}
