using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    public GameObject[] enemies;

    public float maxSpawnTime = 10f, currentTime;

    public Transform[] spawnPoints, endpoints;

    void Start()
    {
        ResetSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            SpawnMan();
            ResetSpawnTime();
        }
    }

    void SpawnMan()
    {
        GameObject man = enemies[Random.Range(0, enemies.Length)];

        Transform start = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Transform end = endpoints[Random.Range(0, endpoints.Length)];

        GameObject runner = Instantiate(man, start.position, Quaternion.identity);

        EnemyController ec = runner.GetComponent<EnemyController>();

        ec.targetTransform = end;
    }

    void ResetSpawnTime()
    {
        currentTime = Random.Range(1, maxSpawnTime);
    }
}
