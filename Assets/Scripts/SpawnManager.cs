using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ballsPrefabs;
    public GameObject bulletPrefab;
    public GameObject[] ballSmallPrefabs;
    private float spawnRangeX = 14.0f;
    private float spawnRangeXX = 55.0f;
    private float spawnRangeZ = -14.6f;
    private float spawnRangeZZ = 30.0f;
    public DetectCollision collisionScript;
    public bool isSmall;
    
    // Start is called before the first frame update
    void Start()
    {
        collisionScript = GameObject.Find("Bigball").GetComponent<DetectCollision>();
        InvokeRepeating("SpawnBalls", 2, 1.5f);
        InvokeRepeating("SpawnBullets", 1, 1.5f);


    }

    // Update is called once per frame
    void Update()
    {
        if (collisionScript.isCollided == true)
        {
            InvokeRepeating("SpawnSmallBalls", 2, 1.5f);
        }


    }
    void SpawnBalls()
    {
        int ballsIndex = Random.Range(0, ballsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeXX), 0, spawnRangeZ);
        Instantiate(ballsPrefabs[ballsIndex], spawnPos, ballsPrefabs[ballsIndex].transform.rotation);

    }
    void SpawnSmallBalls()
    {
        isSmall = true;
        int ballSmallIndex = Random.Range(0, ballSmallPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeXX), 0, spawnRangeZ);
        Instantiate(ballSmallPrefabs[ballSmallIndex], spawnPos, ballsPrefabs[ballSmallIndex].transform.rotation);
        

    }
    void SpawnBullets()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, spawnRangeXX), 0, spawnRangeZZ);
        Instantiate(bulletPrefab, spawnPos, bulletPrefab.transform.rotation);
    }
}
