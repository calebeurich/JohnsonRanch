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

    private void Start()
    {
        SpawnNewWave();
    }

    public void SpawnNewWave()
    {
        enemyCount += 3;
        currentWave++;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        Debug.Log("Starting spawn");

        for (int i = 0; i < enemyCount; i++)
        {
            Debug.Log("Spawn Enemy");
            GameObject randomEnemy = enemyPrefabs[0]; //Random.Range(0, enemyPrefabs.Length)
            Transform spawnLoc = spawnLocations[Random.Range(0, spawnLocations.Length)];

            GameObject newEnemy = Instantiate(randomEnemy, spawnLoc.position, Quaternion.identity);
            newEnemy.GetComponent<DumbZombieBehaviour>().target = transform;
            GameManager.instance.AddEnemy(newEnemy);

            yield return new WaitForSeconds(spawnRate);
        }

        yield return new WaitForSeconds(timeBetweenWaves);
    }
}
