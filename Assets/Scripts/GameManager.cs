using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    public WaveSpawner waveSpawner;
    public bool isSpawning = true;
    private int currentRound = 0;
    private int timeBetweenRounds = 5;
    private List<GameObject> enemyPrefabs;

    //instance variable
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        enemyPrefabs = new List<GameObject>();
    }

    private void Start()
    {
        StartCoroutine(CallSpawnWave());
    }

    private void Update()
    {
        if(EnemyCount() == 0 && !isSpawning)
        {
            StartCoroutine(CallSpawnWave());
        }
    }

    private IEnumerator CallSpawnWave()
    {
        isSpawning = true;
        yield return new WaitForSeconds(timeBetweenRounds);
        Debug.Log("New wave (" + currentRound + ")");
        waveSpawner.SpawnNewWave();
        currentRound++;
        UIManager.instance.NextRound(currentRound);
    }

    public void AddEnemy(GameObject newEnemy)
    {
        enemyPrefabs.Add(newEnemy);
    }

    public void RemoveEnemy(GameObject deleteEnemy)
    {
        enemyPrefabs.Remove(deleteEnemy);
        UIManager.instance.RemainingEnemies(enemyPrefabs.Count);
        Destroy(deleteEnemy);
    }

    public int EnemyCount()
    {
        return enemyPrefabs.Count;

    }
}
