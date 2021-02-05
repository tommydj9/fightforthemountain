﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnRate;
    public Transform[] SpawnGunPosition;
    public GunController[] Guns;
    
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
           StartCoroutine("Timer");

            
        //}
    }

    public void CheckGun()
    {
       float rnd =  Random.Range(0f,1f);
       int rndPosition = Random.Range(0, SpawnGunPosition.Length -1);
       Debug.Log(rnd + " " + rndPosition);

        for (int i = 0; i < Guns.Length; i++)
        {
            if(Guns[i].probilitySpawn > rnd)
            {
                Debug.Log(Guns[i].name);
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
        Instantiate(Guns[0].prefabGun, currentSpawn.position, Quaternion.identity);
    }

    

    IEnumerator Timer()
    {
        //CheckGun();
        yield return new WaitForSeconds(3);
        CheckGun();
        yield return new WaitForSeconds(3);
        CheckGun();
        yield return new WaitForSeconds(3);
        CheckGun();


    }

    //Dentro EnemyController deve esserci la referenza a EnemySpawner
    //Quando Enemy muore chiamo enemySpawner.SpawnEnemy()
    //Fare CheckEnemy (come checkGun ma con gli zombie)

    public void SpawnEnemy()
    {
       StartCoroutine("Timer");
    }

    //StartCoroutine("Timer");


}
