using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI;
public class PickableGun : MonoBehaviour
{
    public GunController gun;
    [Range(1, 99)]
    public int spawnProbability;
    [HideInInspector]
    public Transform currenSpawnPoint;

    private PlayerController player;
    private bool getGun;




    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<PlayerController>())
        {
            player = other.GetComponent<PlayerController>();

            



            //    if (Ho premuto E)
            //    {

            //        if (gun.isEquiped == true)
            //        {
            //            gun.GetAmmo(3);
            //        }
            //        else
            //        {

            //            gun.isEquiped = true;
            //            currenSpawnPoint.gameObject.SetActive(true);

            //            if (player.idPosition < player.SlotGun.Length)
            //            {
            //                player.idPosition++;
            //                gun.gunInOrderID = player.idPosition;
            //                GameObject tempGun = player.SlotGun[gun.gunInOrderID];
            //                Animator tempAnimGun = player.animator[gun.gunInOrderID];
            //                int indexToChange = 0;

            //                for (int j = 0; j < player.SlotGun.Length; j++)
            //                {
            //                    if (player.SlotGun[j].name == gun.name)
            //                    {
            //                        indexToChange = j;
            //                    }
            //                }
            //                Debug.Log("indexToChange: " + indexToChange);
            //                player.SlotGun[gun.gunInOrderID] = player.SlotGun.GetValue(indexToChange) as GameObject;
            //                player.animator[gun.gunInOrderID] = player.animator.GetValue(indexToChange) as Animator;
            //                player.SlotGun[indexToChange] = tempGun;
            //                player.animator[indexToChange] = tempAnimGun;


            //            }

            //            Destroy(transform.gameObject);
            //        }


            //    }


            //}


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (gun.isEquiped == true)
            {
                gun.GetAmmo(3);
            }
            else
            {

                gun.isEquiped = true;
                currenSpawnPoint.gameObject.SetActive(true);

                if (player.idPosition < player.SlotGun.Length)
                {
                    player.idPosition++;
                    gun.gunInOrderID = player.idPosition;
                    GameObject tempGun = player.SlotGun[gun.gunInOrderID];
                    Animator tempAnimGun = player.animator[gun.gunInOrderID];
                    int indexToChange = 0;

                    for (int j = 0; j < player.SlotGun.Length; j++)
                    {
                        if (player.SlotGun[j].name == gun.name)
                        {
                            indexToChange = j;
                        }
                    }
                    Debug.Log("indexToChange: " + indexToChange);
                    player.SlotGun[gun.gunInOrderID] = player.SlotGun.GetValue(indexToChange) as GameObject;
                    player.animator[gun.gunInOrderID] = player.animator.GetValue(indexToChange) as Animator;
                    player.SlotGun[indexToChange] = tempGun;
                    player.animator[indexToChange] = tempAnimGun;


                }

                Destroy(transform.gameObject);
            }


        }
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO: Hide Popup
        getGun = false;
       
    }
}
