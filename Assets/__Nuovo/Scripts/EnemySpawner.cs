using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region OldStuff
    //public EnemyController enemy;

    //private float startTime;


    //private void Start()
    //{
    //    startTime = Time.time;
    //}

    //void SpawnEnemy(int _enemyCounter, float _spawnTime, bool _enemiesAreSpawning)
    //{
    //    StartCoroutine(SpawnEnemyCoroutine(_enemyCounter, _spawnTime, _enemiesAreSpawning)); 
    //}

    //IEnumerator SpawnEnemyCoroutine(int _enemyCounter, float _spawnTime, bool _enemiesAreSpawning)
    //{
    //    float currentEnemiesSpawned = 0;

    //    while (_enemiesAreSpawning)
    //    {
    //        Instantiate(enemy);
    //    }
    //}

    #endregion

    public int enemyFirstSpawnAmount;
    private int enemySpawnAmount;

    int waveNumber = 0;

    [HideInInspector]
    public int enemyToSpawn = 0;
    [HideInInspector]
    public int enemiesKilled = 0;

    public GameObject[] spawnerPoints;
    public GameObject enemy;

    private void Start()
    {
        //for (int i = 0; i < spawnerPoints.Length; i++)
        //{
        //    spawnerPoints[i] = transform.GetChild(i).gameObject;
        //}

        StartWave();
        enemy.transform.gameObject.SetActive(false);
    }

    private void Update()
    {

        Debug.LogFormat("EnemiesKilles: {0} --- enemySpawnAmount: {1}", enemiesKilled, enemySpawnAmount);

        if (enemiesKilled >= enemySpawnAmount)
        {
            NextWave();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawnerPoints.Length);
        enemy.transform.gameObject.SetActive(true);
        Instantiate(enemy, spawnerPoints[spawnerID].transform.position.normalized, spawnerPoints[spawnerID].transform.rotation);
        enemy.transform.gameObject.SetActive(false);
    }

    public void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmount = enemyFirstSpawnAmount;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }

    }

    public void NextWave()
    {
        waveNumber++;
        enemySpawnAmount += 5;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }

    }


}
