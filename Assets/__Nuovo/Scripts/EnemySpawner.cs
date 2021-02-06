using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnRate;
    public Transform[] SpawnGunPosition;
    public EnemyController[] enemy;


     
    void Start()
    {

      }

     
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        


    }

    public void CheckGun()
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

    public void RandomSpawn(int SpawnValue)
    {
        Transform currentSpawn = SpawnGunPosition[SpawnValue];
        Instantiate(enemy[0].prefabEnemy, currentSpawn.position, Quaternion.identity);
    }




    IEnumerator Timer()
    {
        //CheckGun();
        yield return new WaitForSeconds(1000000);
        SpawnEnemy();

    }

    ////Dentro EnemyController deve esserci la referenza a EnemySpawner
    ////Quando Enemy muore chiamo enemySpawner.SpawnEnemy()
    ////Fare CheckEnemy (come checkGun ma con gli zombie)

    public void SpawnEnemy() 
    {
       StartCoroutine("Timer");
       CheckGun();
    }

    


}
