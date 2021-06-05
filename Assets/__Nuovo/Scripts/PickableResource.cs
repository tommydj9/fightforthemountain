using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickableResource : MonoBehaviour
{
   
    public enum ResourceType
    {
        SmallMedkit,
        FullMedikit,
        PoisonMedikit,
        Ammo
    }

    //public GameObject MedKitModeel;
    //public GameObject AmmoModeel;

    public ResourceType resourceType;
    [Range(0, 100)]
    public int spawnProbability;

    [HideInInspector]
    public Transform currentSpawnPoint;


    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            

            //    switch (resourceType)
            //    {
            //        case ResourceType.SmallMedkit:

            //            other.GetComponent<PlayerController>().Heal(20);
            //            Destroy(gameObject);
            //            break;
            //        case ResourceType.FullMedikit:
            //            other.GetComponent<PlayerController>().MaxHeal();
            //            Destroy(gameObject);
            //            break;
            //        case ResourceType.PoisonMedikit:
            //            other.GetComponent<PlayerController>().PoisonHeal(20);
            //            Destroy(gameObject);
            //            break;
            //        case ResourceType.Ammo:
            //            Debug.Log("ammo");
            //            other.GetComponent<PlayerController>().currentGun.GetAmmo(1);
            //            Destroy(gameObject);
            //            break;


            //        default:
            //            break;
            //    }



            //    currentSpawnPoint.gameObject.SetActive(true);
            //    Destroy(transform.gameObject);
            //
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            switch (resourceType)
            {
                case ResourceType.SmallMedkit:

                    other.GetComponent<PlayerController>().Heal(20);
                    Destroy(gameObject);
                    break;
                case ResourceType.FullMedikit:
                    other.GetComponent<PlayerController>().MaxHeal();
                    Destroy(gameObject);
                    break;
                case ResourceType.PoisonMedikit:
                    other.GetComponent<PlayerController>().PoisonHeal(20);
                    Destroy(gameObject);
                    break;
                case ResourceType.Ammo:
                    Debug.Log("ammo");
                    other.GetComponent<PlayerController>().currentGun.GetAmmo(1);
                    Destroy(gameObject);
                    break;


                default:
                    break;
            }



            currentSpawnPoint.gameObject.SetActive(true);
            Destroy(transform.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

} 


