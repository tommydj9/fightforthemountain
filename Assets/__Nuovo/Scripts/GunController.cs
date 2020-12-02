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
    public GameObject damagePopup;

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

    Vector3 popUpOffset = new Vector3(0,37f,100);
    Vector3 popupRandomIntensity = new Vector3(17f, 7f, 0);


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

                    Quaternion sistemaRotation = Quaternion.identity;
                    sistemaRotation.eulerAngles = new Vector3(-90, 0, 0);

                    GameObject bloods = Instantiate(Sistema, damageController.enemy.head.transform.position, sistemaRotation);
                    bloods.transform.parent = damageController.transform;

                    ShowDamage(headDamage,_hit.point,damageController.enemy,Color.blue);

                    break;
                case DamageController.BodyParts.body:
                    damageController.Hit(bodyDamage);
                    ShowDamage(bodyDamage, _hit.point, damageController.enemy, Color.blue);


                    break;
                case DamageController.BodyParts.legs:
                    damageController.Hit(legsDamage);
                    ShowDamage(legsDamage, _hit.point, damageController.enemy, Color.blue);
                    break;
                case DamageController.BodyParts.arms:
                    damageController.Hit(armsDamage);
                    ShowDamage(armsDamage, _hit.point, damageController.enemy, Color.blue);
                    break;
                case DamageController.BodyParts.feet:
                    damageController.Hit(feetDamage);
                    ShowDamage(feetDamage, _hit.point, damageController.enemy, Color.blue);
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

    private void ShowDamage(float _damage, Vector3 _hitPoint, EnemyController _enemy, Color _color)
    {
        if (damagePopup != null && _enemy.life > 0)
        {
            //Posizioni
            Vector3 popupPosition = _hitPoint + popUpOffset + new Vector3(Random.Range(-popupRandomIntensity.x, popupRandomIntensity.x), 
                                                                          Random.Range(-popupRandomIntensity.y, popupRandomIntensity.y), 0);

            GameObject popup = Instantiate(damagePopup, popupPosition, Quaternion.identity);
            popup.GetComponent<TextMesh>().text = _damage.ToString();
            popup.GetComponent<TextMesh>().color = _color;

            Destroy(popup, 2f);



        } 
    }

    

    
}
