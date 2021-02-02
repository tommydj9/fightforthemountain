using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GunController : MonoBehaviour
{

    //Inspector
    public PlayerMovement player;
    public float damage;
    public float distance;
    public Camera mainCamera;
    public GameObject damagePopup;
    public int ammo;
    public  int currentCartdrigeSize;
    public int cartdrigeSize = 6;
    public int cartdirges = 3;
    public bool isReloading = false;

    public float fireRatio = 5;
    public float reloadAnimationTime = 2f; 
    public GameObject hitEffect;
    public GameObject Sistema;
    public AudioSource audioSource;
    public AudioClip shootingSound;
    public AudioClip ReloadSound;
    public UIManager UImanager;

    public Image gunImage;//Senza contorno
    public Image gunImageSelected; //Con contorno
    public Sprite CrosshairImage;
    [Range(0,1)]
    public float probilitySpawn;
    public GameObject prefabGun;

    [Header("Rockets Information")]
    public bool hasRockets;
    public float explosionDamage;
    public float TimeRocket;
    public float explosionRadius;
    public float explosionForce;
    public GameObject RocketPrefab;
    public ParticleSystem explosionEffect;
    public ParticleSystem fireEffect;
    private bool shootedRocket;
    private GameObject Rocket;

    /*
     * Quando switcho arma:
     * controllo l'index
     * faccio un for e
     * Se l'index dell' immagine = index arma
     * allora attivo gunImageSelected
     * 
     * altrimenti attivo gunImage
     * 
     * 
     * 
     */





    //Public
    [HideInInspector]
    public DamageController damageController;


    //Private
    Animator playerAnimator;
    private float fireRatioTime;
    int bodyDamage = 60;
    int headDamage = 40;
    int armsDamage = 60;
    int feetDamage = 60;
    int legsDamage = 60;
    float reloadTime = 0;

    Vector3 popUpOffset = new Vector3(0,37f,100);
    Vector3 popupRandomIntensity = new Vector3(17f, 7f, 0);

    private void Awake()
    {
        playerAnimator = player.CurrentAnimator;
        currentCartdrigeSize = 6;
        currentCartdrigeSize = cartdrigeSize;
        ammo = cartdrigeSize * cartdirges;
        UImanager.SetUiAmmo(currentCartdrigeSize.ToString());


        
    }
    private void Start()
    {
        
        playerAnimator.SetInteger("Movement", 0);
        fireEffect.gameObject.SetActive(false);

    }


    void Update()
    {
        Shoot();
        Reload();
        playerAnimator = player.CurrentAnimator;
    }


    public void Shoot()
    {
        if (Input.GetButton("Fire1")  && currentCartdrigeSize == 0) {
            //Aggiungere suono caricatore vuoto

        }

        if (Input.GetButton("Fire1") && fireRatioTime <= Time.time && currentCartdrigeSize > 0)
        {
            
            audioSource.PlayOneShot(shootingSound);

            fireRatioTime = Time.time + (1f / fireRatio);
            playerAnimator.SetInteger("Fire", 2);
            currentCartdrigeSize--;
            UImanager.SetUiAmmo(currentCartdrigeSize.ToString());



            //Sparo
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, distance))
            {
                //Debug.Log(hit.transform.gameObject.name);

                /*
                 * Controllo se l'arma spara razzi (== per il controllo)
                 * prendo l'informazione hit.point per sapere dove andrà il razzo
                 * Istanziare il razzo nel punto rocketStart (o aggiungi rocketstart sull'inspector oppure usi direttamente la transform dell'arma)
                 * GameObject rocket = Instatiate(oggetto da istanziare, pos, Quaternion.identity);
                 * rocket.DOMove(hit.point, velocità razzo)
                 * OnComplete, far partire un effetto nella posizione hitpoint
                 * 
                 */

                if (hasRockets == true && !shootedRocket)
                {
                    Vector3 RocketPosition = hit.point;
                    explosionEffect.Stop();
                    explosionEffect.gameObject.SetActive(false);
                    Rocket = Instantiate(RocketPrefab, transform.position, transform.rotation * new Quaternion(0,180,0,0));
                    if (!shootedRocket)
                    {
                        shootedRocket = true;
                        fireEffect.gameObject.SetActive(true);
                        fireEffect.transform.parent = Rocket.transform.GetChild(1).transform;
                        fireEffect.transform.localPosition = Vector3.zero;
                        fireEffect.transform.localScale = Vector3.one;
                        fireEffect.Play();
                        Rocket.transform.DOMove(RocketPosition, TimeRocket).OnComplete(() => RocketImpact(RocketPosition)); 
                    }

                }
                else if(!hasRockets)
                {
                    checkShoot(hit);
                }

                


                //checkHit(hit);
                if (!hasRockets)
                {
                    GameObject hitEffectObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(hitEffectObject, 1f);
                }

            }

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            playerAnimator.SetInteger("Fire", -1);
            playerAnimator.SetInteger("Movement", 0);
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && isReloading == false && cartdirges > 0 && currentCartdrigeSize < 1)
        {
            reloadTime = reloadAnimationTime;
            playerAnimator.SetInteger("Reload", 1);
            audioSource.PlayOneShot(ReloadSound);
            


            isReloading = true;
        }
        if (reloadTime <= 1 && isReloading == true)
        {
            isReloading = false;
            reloadTime = 0;
            playerAnimator.SetInteger("Reload", -1);
            //cartdirges = caricaTORI
            //cartdrigeSize = capienza caricatore
            // ammo = munizioni totali 
            //currentCartdirge proiettili che hai nel caricatori 

            currentCartdrigeSize = cartdrigeSize;
            ammo = ammo - currentCartdrigeSize - cartdrigeSize; //sottrendo currenSize è come nella realtà
            UImanager.SetUiAmmo(currentCartdrigeSize.ToString());

            cartdirges--;
            // 3 = 3 - 1 - 6

            // muniz = 3
            // currentC = 1
            // current = 4

            

        }
        else
        {
            reloadTime -= Time.deltaTime;
        }
    }



    //bool isReloading() {
    //    if (reloadTime <= 0) {
    //        return false;
    //    }
    //    else {
    //        return true;
    //    }

    //    return (reloadTime <= 0 ? false : true);

    //}

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

    private void RocketImpact(Vector3 _impactPos)
    {
        PhysicsExplosion(_impactPos);
        shootedRocket = false;
        explosionEffect.transform.position = _impactPos;
        explosionEffect.gameObject.SetActive(true);
        explosionEffect.Play();
        fireEffect.Stop();
        fireEffect.gameObject.SetActive(false);
        fireEffect.transform.parent = null;
        Destroy(Rocket,.5f);
    }

    private void PhysicsExplosion(Vector3 _impactPos)
    {
        Collider[] hitColliders = Physics.OverlapSphere(_impactPos, explosionRadius);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.GetComponent<Rigidbody>() != null)
            {
                hitCollider.GetComponent<Rigidbody>().isKinematic = false;
                hitCollider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, _impactPos, explosionRadius, .02f, ForceMode.Impulse); 
            }

            if (hitCollider.GetComponent<EnemyController>())
            {
                hitCollider.GetComponent<EnemyController>().life -= explosionDamage;
                ShowDamage(explosionDamage, _impactPos, hitCollider.GetComponent<EnemyController>(), Color.blue);
            }
        }

    }





}
