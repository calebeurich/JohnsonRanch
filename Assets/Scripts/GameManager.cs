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

    private void Update()
    {
        if(EnemyCount() == 0 && !isSpawning)
        {
            isSpawning = true;
            waveSpawner.SpawnNewWave();
            currentRound++;
            Debug.Log("New wave");
            UIManager.instance.NextRound(currentRound);
        }
    }

    public void AddEnemy(GameObject newEnemy)
    {
        enemyPrefabs.Add(newEnemy);
        Debug.Log("Add enemy");
    }

    public void RemoveEnemy(GameObject deleteEnemy)
    {
        Debug.Log("Remove enemy");
        enemyPrefabs.Remove(deleteEnemy);
        Destroy(deleteEnemy);
    }

    public int EnemyCount()
    {
        return enemyPrefabs.Count;

    }
}
