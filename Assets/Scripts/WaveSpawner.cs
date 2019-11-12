using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnLocations;
    public float spawnRate = 1;
    public int timeBetweenWaves = 15;

    private int currentWave = 0;
    private int enemyCount = 0;

    public void SpawnNewWave()
    {
        enemyCount += 3;
        currentWave++;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Transform spawnLoc = spawnLocations[Random.Range(0, spawnLocations.Length)];

            GameObject newEnemy = Instantiate(randomEnemy, spawnLoc);

            GameManager.instance.AddEnemy(newEnemy);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
