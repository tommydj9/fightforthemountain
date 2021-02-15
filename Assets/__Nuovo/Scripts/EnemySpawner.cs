using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnRate;
    public Transform[] SpawnGunPosition;
    public EnemyController[] enemy;
    private bool canSpawnEnemy;
    private int numberToEnemySpawn;
    public int currentZombieSpawn;



    void Start()
    {
        canSpawnEnemy = true;
    }


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{




    }

    public void CheckEnemy()
    {
        if (canSpawnEnemy == true)
        {

            float rnd = Random.Range(0f, 1f);
            int rndPosition = Random.Range(0, SpawnGunPosition.Length - 1);
            Debug.Log(rnd + " " + rndPosition);

            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].probabilitySpawn > rnd)
                {
                    Debug.Log(enemy[i].name);
                    RandomSpawn(rndPosition);

                }
                else
                {
                    Debug.Log("Null");

                }

            }
        }
    }

    public void RandomSpawn(int SpawnValue)
    {
        Transform currentSpawn = SpawnGunPosition[SpawnValue];
        Instantiate(enemy[0].prefabEnemy, currentSpawn.position, Quaternion.identity);
        

    }

    




    IEnumerator Timer()
    {
        //CheckGun();
        if (numberToEnemySpawn > 0)
        {
            CheckEnemy();
            numberToEnemySpawn--;
        }
        canSpawnEnemy = false;
        yield return new WaitForSeconds(3);
        canSpawnEnemy = true;
        
        

    }
     
    ////Dentro EnemyController deve esserci la referenza a EnemySpawner
    ////Quando Enemy muore chiamo enemySpawner.SpawnEnemy()
    ////Fare CheckEnemy (come checkGun ma con gli zombie)

    public void SpawnEnemy(int _maxToSpawn, int _currentZombieNow)
    {
        StartCoroutine("Timer");
        currentZombieSpawn = _currentZombieNow;
        numberToEnemySpawn = _maxToSpawn - currentZombieSpawn;

        


    }




}
