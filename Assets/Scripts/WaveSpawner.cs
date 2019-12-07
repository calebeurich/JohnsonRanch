using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnLocations;
    public Transform playerTransform;
    public Transform houseTransform;
    public float spawnRate = 1;
    private int enemyCount = 0;

    public void SpawnNewWave()
    {
        enemyCount += 3;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        UIManager.instance.RemainingEnemies(enemyCount);

        for (int i = 0; i < enemyCount; i++)
        {
            //int randInt = Random.Range(0, enemyPrefabs.Length);
            int randInt = 0;
            GameObject randomEnemy = enemyPrefabs[randInt];
            Transform spawnLoc = spawnLocations[Random.Range(0, spawnLocations.Length)];
            GameObject newEnemy = Instantiate(randomEnemy, spawnLoc.position, Quaternion.identity);
            if(randInt == 1)
            {
                newEnemy.GetComponent<StealyZombie>().target = houseTransform;
            }
            else
            {
                newEnemy.GetComponent<DumbZombieBehaviour>().target = playerTransform;
            }
            
            GameManager.instance.AddEnemy(newEnemy);

            yield return new WaitForSeconds(spawnRate);
        }

        GameManager.instance.isSpawning = false;
    }
}
