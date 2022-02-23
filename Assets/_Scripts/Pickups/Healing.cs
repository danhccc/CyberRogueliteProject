using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
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
        print("YES");
        if (other.gameObject.CompareTag("Player") && pb.health < 100)
        {
            pb.health = 100;
            Destroy(this.gameObject);
        }
    }
}
