using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] pickups;
    public float startMaxTimeBtwSpawn;
    float timeBtwSpawn;

    private void Awake()
    {
        float newMaxTime = Random.Range(startMaxTimeBtwSpawn - 1, startMaxTimeBtwSpawn + 1);
        timeBtwSpawn = newMaxTime;
    }

    private void Update()
    {
        timeBtwSpawn -= Time.deltaTime;

        if (timeBtwSpawn <= 0)
        {
            Instantiate(pickups[Random.Range(0, pickups.Length)], transform.position, Quaternion.identity);
            float newMaxTime = Random.Range(startMaxTimeBtwSpawn - 1, startMaxTimeBtwSpawn + 1);
            timeBtwSpawn = newMaxTime;
        }
    }
}
