using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] pickups;
    public Transform[] spawnPoints;
    public float startMaxTimeBtwSpawn;
    
    float timeBtwSpawn;
    float minTimeBtwSpawn = 0.5f;

    private void Awake()
    {
        float newMaxTime = Random.Range(startMaxTimeBtwSpawn - 1f, startMaxTimeBtwSpawn + 1f);
        timeBtwSpawn = newMaxTime;
    }

    private void Update()
    {
        timeBtwSpawn -= Time.deltaTime;

        if (timeBtwSpawn <= 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i != randomIndex)
                    Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoints[i].transform.position, Quaternion.identity);
                else
                    Instantiate(pickups[Random.Range(0, pickups.Length)], spawnPoints[i].transform.position, Quaternion.identity);
            }
            float newMaxTime = Random.Range(startMaxTimeBtwSpawn - 0.25f, startMaxTimeBtwSpawn + 0.25f);
            if (newMaxTime > minTimeBtwSpawn)
            {
                timeBtwSpawn = newMaxTime;
                startMaxTimeBtwSpawn *= 0.95f;
            } else
            {
                timeBtwSpawn = minTimeBtwSpawn;
            }

        }
    }
}
