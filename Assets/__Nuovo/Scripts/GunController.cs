using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public float damage;
    public float distance;
    public Camera mainCamera;

    public float fireRatio = 5;
    private float fireRatioTime;
    public GameObject hitEffect;


    
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
                //Nemico.TakeDamage();

                GameObject hitEffectObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffectObject, 1f);

                }


        }

    }
}
