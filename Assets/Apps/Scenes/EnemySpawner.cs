using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float initialSpawnRate = 0.5f;
    public float minSpawnRate = 0.1f;
    public float spawnRateDecrease = 0.01f;
    private float currentSpawnRate;
    private float timer = 0f;

    public float spawnRadius = 10f; 
    public float minSpawnDistance = 3f;

    void Start()
    {
        currentSpawnRate = initialSpawnRate;
        SpawnEnemy();
    }

    void Update()
    {
        if (timer < currentSpawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            timer = 0f;
        }

        if (currentSpawnRate > minSpawnRate)
        {
            currentSpawnRate -= spawnRateDecrease * Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition;
        do
        {
            float randomAngle = Random.Range(0f, 360f);
            float randomDistance = Random.Range(minSpawnDistance, spawnRadius);
            spawnPosition = player.position + new Vector3(Mathf.Cos(randomAngle) * randomDistance, Mathf.Sin(randomAngle) * randomDistance, 0);
        }
        while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistance);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
