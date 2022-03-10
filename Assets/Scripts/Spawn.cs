using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab, powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    void Start()
    {
        GenerateSpawn(waveNumber);
        Instantiate(powerupPrefab, SpawnEnemy(), powerupPrefab.transform.rotation);
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            GenerateSpawn(waveNumber);
            Instantiate(powerupPrefab, SpawnEnemy(), powerupPrefab.transform.rotation);
        }
    }
    public void GenerateSpawn(int enemiesSpawn)
    {
        for (int i = 0; i < enemiesSpawn; i++)
        {
            Instantiate(enemyPrefab, SpawnEnemy(), enemyPrefab.transform.rotation);
        }
    }
    public Vector3 SpawnEnemy()
    {
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnX, 0, spawnZ);
        return randomPos;
    }
}
