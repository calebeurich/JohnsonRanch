using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance { get { return _instance; } }

    public WaveSpawner waveSpawner;

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
        if(enemyPrefabs.Count == 0)
        {
            waveSpawner.SpawnNewWave();
        }
    }

    public void AddEnemy(GameObject newEnemy)
    {
        enemyPrefabs.Add(newEnemy);
    }

    public void RemoveEnemy(GameObject deleteEnemy)
    {
        enemyPrefabs.Remove(deleteEnemy);
    }
}
