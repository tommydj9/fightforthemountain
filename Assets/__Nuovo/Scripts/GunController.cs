using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{

    //Inspector
    public float damage;
    public float distance;
    public Camera mainCamera;

    public float fireRatio = 5;
    public GameObject hitEffect;
    public GameObject Sistema;


    //Public
    [HideInInspector]
    public DamageController damageController;


    //Private
    private float fireRatioTime;
    int bodyDamage = 60; 
    int headDamage = 40; 
    int armsDamage = 60;
    int feetDamage = 60;
    int legsDamage = 60;
    




    void Update()
    {

        if (Input.GetButton("Fire1") && fireRatioTime <= Time.time)
        {

            fireRatioTime = Time.time + (1f / fireRatio);

            //Sparo
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
                {
                    Debug.Log(hit.transform.gameObject.name);
                    checkShoot(hit);
               

                //checkHit(hit);

                GameObject hitEffectObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffectObject, 1f);

                }

        }

    }


    //
    public void checkShoot(RaycastHit _hit)
    {
        try
        {
            damageController = _hit.transform.GetComponent<DamageController>();
            switch (damageController.bodyParts)
            {
                case DamageController.BodyParts.head:
                    damageController.Hit(headDamage);
                    damageController.enemy.head.transform.localScale = Vector3.zero;
                    Instantiate(Sistema, damageController.enemy.head.transform.position, Quaternion.identity);
                    



                    break;
                case DamageController.BodyParts.body:
                    damageController.Hit(bodyDamage);
                    
                    

                    break;
                case DamageController.BodyParts.legs:
                    damageController.Hit(legsDamage);
                    break;
                case DamageController.BodyParts.arms:
                    damageController.Hit(armsDamage);
                    break;
                case DamageController.BodyParts.feet:
                    damageController.Hit(feetDamage);
                    break;
                default:
                    break;
            }
            
        }
        catch
        {
            Debug.LogWarning("Not enemy");
        }
        
    }

    
}
