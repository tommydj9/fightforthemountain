using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableResource : MonoBehaviour
{
    
    public enum ResourceType
    {
        Medkit,
        Ammo
    }

    //public GameObject MedKitModeel;
    //public GameObject AmmoModeel;

    public ResourceType resourceType;
    [Range(0,100)]
    public int spawnProbability;

    [HideInInspector]
    public Transform currentSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            switch (resourceType)
            {
                case ResourceType.Medkit:
                    //other.GetComponent<PlayerController>().Heal();
                    break;
                case ResourceType.Ammo:
                    //other.GetComponent<PlayerController>().CurrentGun.GetAmmo();
                    break;
                default:
                    break;
            }

            currentSpawnPoint.gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }


}
