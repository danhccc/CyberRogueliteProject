using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;

    [SerializeField] public int numberOfSpawner;
    [SerializeField] public float spawnInterval = 2.0f;

    public float spawnTimer;
    public float totalTime;
    
    // Start is called before the first frame update
    void Start()
    {
        //spawners = new GameObject[numberOfSpawner];

        //for (int i = 0; i < spawners.Length; i++)
        //{
        //    spawners[i] = transform.GetChild(i).gameObject;
        //}
        //StartCoroutine(spawnEnemyTimer(spawnInterval, enemy));
        //StartCoroutine(spawnInTime());
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        if (totalTime <= 30)
        {
            if (spawnTimer >= 3.0f)
            {
                spawn();
                spawnTimer = 0;
            }
        }
        else if (totalTime > 30 && totalTime <= 60)
        {
            if (spawnTimer >= 2.0f)
            {
                spawn();
                spawnTimer = 0;
            }
        }
        else
        {
            if (spawnTimer >= 1.0f)
            {
                spawn();
                spawnTimer = 0;
            }
        }
    }

    //private void SpawnEnemy()
    //{
    //    int spawnerID = Random.Range(0, spawners.Length);
    //    Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    //}

    //private IEnumerator spawnEnemyTimer(float interval, GameObject enemy)
    //{
    //    yield return new WaitForSeconds(interval);
    //    Debug.Log("Enemy POP!");
    //    GameObject newEnemy = Instantiate(enemy, new Vector3(0,0, 0), Quaternion.identity);
    //}

    //private IEnumerator spawnInTime()
    //{
    //    yield return new WaitForSeconds(2.0f);
    //    Debug.Log("Enemy POP!");
    //}

    private void spawn()
    {
        int spawnID = Random.Range(0, 3);

        Instantiate(enemy, spawners[spawnID].transform.position, Quaternion.identity);
    }
}
