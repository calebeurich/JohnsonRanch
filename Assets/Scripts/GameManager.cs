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
    public int timeBetweenRounds = 5;
    public bool isAlive = true;
    private List<GameObject> enemyPrefabs;
    private int score = 0;
    private int lives = 3;

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
        UIManager.instance.GameStart();
        StartCoroutine(CallSpawnWave());
    }

    private void Update()
    {
        if (lives == 0 && isAlive)
        {
            isAlive = false;
            UIManager.instance.GameOver();
        }
        if (EnemyCount() == 0 && !isSpawning)
        {
            StartCoroutine(CallSpawnWave());
        }
    }

    private IEnumerator CallSpawnWave()
    {
        isSpawning = true;
        yield return new WaitForSeconds(timeBetweenRounds);
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
        score++;
        UIManager.instance.UpdateScore(score);
    }

    public int EnemyCount()
    {
        return enemyPrefabs.Count;

    }
    public void DecreaseLives()
    {
        lives--;
        UIManager.instance.SetLives(lives);
    }

}
