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

    private PlayerController player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            player = other.GetComponent<PlayerController>();
            gun.isEquiped = true;
            currenSpawnPoint.gameObject.SetActive(true);

            if (player.idPosition < player.SlotGun.Length)
            {
                player.idPosition++;
                gun.gunInOrderID = player.idPosition;
                GameObject tempGun = player.SlotGun[gun.gunInOrderID];
                Animator tempAnimGun = player.animator[gun.gunInOrderID];
                int indexToChange = 0;
                for (int i = 0; i < player.SlotGun.Length; i++)
                {
                    if (player.SlotGun[i].name == gun.name)
                    {
                        indexToChange = i; 
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
