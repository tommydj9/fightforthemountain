using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableGun : MonoBehaviour
{
    public GunController gun;
    [Range(1,99)]
    public int spawnProbability;
    [HideInInspector]
    public Transform currenSpawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            gun.isEquiped = true;
            currenSpawnPoint.gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }

        
    }

}
