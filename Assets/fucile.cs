using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fucile : MonoBehaviour
{
    
    public Transform puntoProiettili;
    public GameObject esplosione;
    public GameObject flash;
    public AudioSource audioSource;
   

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            shoot();

            gameObject.GetComponent<AudioSource>().Play();
           
        }
    }

    void shoot()
    {
        RaycastHit oggettoColpito;

        Instantiate(flash, puntoProiettili.position, puntoProiettili.rotation);

        if (Physics.Raycast(puntoProiettili.position, puntoProiettili.forward, out oggettoColpito, 15f))
        {



            Instantiate(esplosione, oggettoColpito.point, Quaternion.LookRotation(oggettoColpito.normal));


            if (oggettoColpito.transform.tag == "zombie")
            {

                Destroy(oggettoColpito.transform.gameObject);
                

            }

            if (oggettoColpito.transform.tag == "zombie")
            {

                GameControlScript.moneyAmount += 1;

            }

        }
       

    }
}
