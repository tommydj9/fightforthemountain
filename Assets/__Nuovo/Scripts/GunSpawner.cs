using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public float spawnTimer;
    public float spawnRate;
    public Transform[] SpawnGunPosition;
    public GunController[] Guns;
    private bool canSpawnGun;
    
  
    // Start is called before the first frame update
    void Start()
    {
        canSpawnGun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnGun == true)
        {
            StartCoroutine("Timer");

        }
    }

    public void CheckGun()
    {
       float rnd =  Random.Range(0f,1f);
       int rndPosition = Random.Range(0, SpawnGunPosition.Length -1);

        for (int i = 0; i < Guns.Length; i++)
        {
            if(Guns[i].probilitySpawn > rnd)
            {
                //Debug.Log(Guns[i].name);
                RandomSpawn(rndPosition,i);
                break;
            }
            else
            {
                //Debug.Log("Null");
                
            }

        }
        
       
    }

    public void RandomSpawn(int SpawnValue, int index)
    {
        
        Transform currentSpawn = SpawnGunPosition[SpawnValue];
        //Debug.Log("random spawn");
        Instantiate(Guns[index].prefabGun, currentSpawn.position, Quaternion.identity);
    }



    IEnumerator Timer()
    {
        canSpawnGun = false;
        yield return new WaitForSeconds(3);
        canSpawnGun = true;

        CheckGun();

    }



    public void SpawnEnemy()
    {
        StartCoroutine("Timer");
    }



}
