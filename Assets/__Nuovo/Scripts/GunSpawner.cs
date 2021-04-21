using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : MonoBehaviour
{
    public float spawnTimer;
    public Transform[] SpawnGunPosition;
    public PickableGun[] pickableGuns;
    private bool canSpawnGun;
    [Range(1, 100)]
    public int probBetweenGunAndResourced;
    public PickableResource[] pickableResources;
    
  
    // Start is called before the first frame update
    void Start()
    {
        canSpawnGun = true;
    }

    
    void Update()
    {
        if (canSpawnGun == true)
        {
            StartCoroutine("Timer");

        }
    }

    public void CheckGun()
    {
       int rnd =  Random.Range(1,100);
       int rndPosition = Random.Range(0, SpawnGunPosition.Length );

        OrderGunsByProbability();

        for (int i = 0; i < pickableGuns.Length; i++)
        { 
            if (rnd < pickableGuns[i].spawnProbability)
            {
                GunRandomSpawn(rndPosition, i);
                break;
            }
        }

       
    }


    public void CheckResources()
    {
        int rnd = Random.Range(1, 100);
        int rndPosition = Random.Range(0, SpawnGunPosition.Length);

        OrderResourcesOnProbability();

        for (int i = 0; i < pickableResources.Length; i++)
        {
            if (rnd < pickableResources[i].spawnProbability)
            {
                ResourceRandomSpawn(rndPosition, i);
                break;
            }
        }
    }



    public void OrderGunsByProbability()
    {
       PickableGun temp;
        for (int i = 0; i < pickableGuns.Length; i++)
        {
            for (int j = 0; j < pickableGuns.Length -1; j++)
            {
                if (pickableGuns[j].spawnProbability > pickableGuns[j +1].spawnProbability)
                {
                    temp = pickableGuns[j + 1];
                    pickableGuns[j + 1] = pickableGuns[j];
                    pickableGuns[j] = temp;
                    
                }
            }
        }
    }


    void OrderResourcesOnProbability()
    {
        PickableResource temp;

        for (int i = 0; i < pickableResources.Length; i++)
        {
            for (int j = 0; j < pickableResources.Length - 1; j++)
            {
                if (pickableResources[j].spawnProbability > pickableResources[j + 1].spawnProbability)
                {
                    temp = pickableResources[j + 1];
                    pickableResources[j + 1] = pickableResources[j];
                    pickableResources[j] = temp;
                }
            }
        }
    }

    public void GunRandomSpawn(int SpawnValue, int index)
    {
        
        Transform currentSpawn = SpawnGunPosition[SpawnValue];
        //Debug.Log("random spawn");
        if (currentSpawn.gameObject.activeSelf)
        {
            pickableGuns[index].currenSpawnPoint = currentSpawn;
            Instantiate(pickableGuns[index], currentSpawn.position, Quaternion.identity);
            currentSpawn.gameObject.SetActive(false);
        }
        
    }

    
    public void ResourceRandomSpawn(int SpawnValue, int index)
    {

        Transform currentSpawn = SpawnGunPosition[SpawnValue];
        if (currentSpawn.gameObject.activeSelf)
        {
            pickableResources[index].currentSpawnPoint = currentSpawn;
            Instantiate(pickableResources[index], currentSpawn.position, Quaternion.identity);
            currentSpawn.gameObject.SetActive(false);
        }

    }




    IEnumerator Timer()
    {
        canSpawnGun = false;
        yield return new WaitForSeconds(spawnTimer);
        canSpawnGun = true;
        int rnd = Random.Range(1, 100);
        if (rnd < probBetweenGunAndResourced)
        {
            CheckGun();
        }
        else
        {
            CheckResources();
        }


    }



    public void SpawnEnemy()
    {
        StartCoroutine("Timer");
    }



}
