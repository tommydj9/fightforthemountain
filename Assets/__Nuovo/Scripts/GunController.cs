using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GunController : MonoBehaviour
{

    //Inspector
    public PlayerController player;
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
    public float TimeCrosshair;
    

    [Header("Rockets Information")]
    public bool hasRockets;
    public float explosionDamage;
    public float RocketSpeed;
    public float explosionRadius;
    public float explosionForce;
    public GameObject RocketPrefab;
    public ParticleSystem explosionEffect;
    public ParticleSystem fireEffect;
    private bool shootedRocket;
    private GameObject Rocket;
    public Transform rocketStartPosition;
    public GameObject attachedRocketModel;
    public float Rocketspeed;
    
    
    

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
    [HideInInspector]
    public EnemyController enemy;


    //Private
    Animator playerAnimator;
    private float fireRatioTime;
    int bodyDamage = 60;
    int headDamage = 40;
    int armsDamage = 60;
    int feetDamage = 60;
    int legsDamage = 60;
    float reloadTime = 0;

    Vector3 popUpOffset = new Vector3(0,7f, 5);
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
        if (hasRockets)
        {
            fireEffect.gameObject.SetActive(false);
        }

    }


    void Update()
    {
        Mira();
        Shoot();
        Reload();
        playerAnimator = player.CurrentAnimator;
    }

    public void Mira()
    {
        if (Input.GetButtonDown("Fire2"))
        {

            UImanager.actualCrosshairImage.transform.DOScale(new Vector3(0.08f,0.14f,1f), TimeCrosshair);
            playerAnimator.SetBool("Sight", true);
            
        }


        if (Input.GetButtonUp("Fire2"))
        {
            UImanager.actualCrosshairImage.transform.DOScale(new Vector3(0.22f, 0.39f, 1f), TimeCrosshair);
            playerAnimator.SetBool("Sight", false);
            
        }
    }
    public void Shoot()
    {
        

        if (Input.GetButton("Fire1")  && currentCartdrigeSize == 0) {
            //Aggiungere suono caricatore vuoto
            playerAnimator.SetInteger("Fire", -1);
            playerAnimator.SetInteger("Movement", 0);

        }
        

        if (Input.GetButton("Fire1") && fireRatioTime <= Time.time && currentCartdrigeSize > 0)
        {
            
            audioSource.PlayOneShot(shootingSound);
            playerAnimator.SetInteger("Fire", 2);
            fireRatioTime = Time.time + (1f / fireRatio);
           
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

                if (!hasRockets)
                {
                    GameObject hitEffectObject = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(hitEffectObject, 1f);
                    checkShoot(hit);
                }

                if (hasRockets == true && !shootedRocket)
                {
                    Vector3 RocketPosition = hit.point;
                    explosionEffect.Stop();
                    explosionEffect.gameObject.SetActive(false);
                    Rocket = Instantiate(RocketPrefab, rocketStartPosition.transform.position, transform.rotation * new Quaternion(0,180,0,0));
                    attachedRocketModel.SetActive(false);
                    
                    if (!shootedRocket)
                    {
                        shootedRocket = true;
                        fireEffect.gameObject.SetActive(true);
                        fireEffect.transform.parent = Rocket.transform.GetChild(1).transform;
                        fireEffect.transform.localPosition = Vector3.zero;
                        fireEffect.transform.localScale = Vector3.one;
                        fireEffect.Play();
                        float distance = Vector3.Distance(Rocket.transform.position, RocketPosition);
                        Rocket.transform.DOMove(RocketPosition, distance/RocketSpeed).OnComplete(() => RocketImpact(RocketPosition)); 
                        
                      
                    }

                }
               

                


                //checkHit(hit);
                

            }
            else
            {
                Debug.Log("entry");
                if (Rocket != null)
                {
                    Rocket = Instantiate(RocketPrefab, rocketStartPosition.transform.position, transform.rotation * new Quaternion(0, 180, 0, 0));
                    Vector3 rocketDestination = transform.forward * 10;
                    Rocket.transform.DOMove(rocketDestination, RocketSpeed + 6f);
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
            damageController = _hit.transform.GetComponentInChildren<DamageController>();
            enemy = _hit.transform.GetComponent<EnemyController>();
            
            switch (damageController.bodyParts)
            {

                case DamageController.BodyParts.head:
                    Debug.Log("HEAD");
                    
                    damageController.Hit(headDamage);
                    damageController.enemy.head.transform.localScale = Vector3.zero;
                    damageController.enemy.playerFound = true;

                    Quaternion sistemaRotation = Quaternion.identity;
                    sistemaRotation.eulerAngles = new Vector3(-90, 0, 0);

                    GameObject bloods = Instantiate(Sistema, damageController.enemy.head.transform.position, sistemaRotation);
                    bloods.transform.parent = damageController.transform;

                    ShowDamage(headDamage, _hit.point, enemy, Color.blue);
                    break;
                case DamageController.BodyParts.body:
                    Debug.Log("CHECK SHOOT: " + bodyDamage);
                    damageController.Hit(bodyDamage);
                    ShowDamage(bodyDamage, _hit.point, enemy, Color.blue);
                    break;
                case DamageController.BodyParts.legs:
                    damageController.Hit(legsDamage);
                    ShowDamage(legsDamage, _hit.point, enemy, Color.blue);
                    break;
                case DamageController.BodyParts.arms:
                    damageController.Hit(armsDamage);
                    ShowDamage(armsDamage, _hit.point, enemy, Color.blue);
                    break;
                case DamageController.BodyParts.feet:
                    damageController.Hit(feetDamage);
                    ShowDamage(feetDamage, _hit.point, enemy, Color.blue);
                    break;
                default:
                    Debug.Log("damageController: " + damageController.bodyParts);
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
            Debug.Log("DamagePopUp: " + damagePopup);
            //Posizioni
            Vector3 popupPosition = popUpOffset + new Vector3(Random.Range(-popupRandomIntensity.x, popupRandomIntensity.x), 
                                                                          Random.Range(-popupRandomIntensity.y, popupRandomIntensity.y), 0);

            GameObject popup = Instantiate(damagePopup, _enemy.transform.position, Quaternion.identity);
            popup.transform.rotation = transform.rotation;
            popup.transform.parent = _enemy.transform;
            popup.transform.localPosition = new Vector3(0,0,-60);
            popup.GetComponent<TextMesh>().text = _damage.ToString();
            popup.GetComponent<TextMesh>().color = _color;

            Destroy(popup, 2f);

        }else if(damagePopup == null)
        {
            Debug.Log("DamagePopUp is null");
        }
    }

    private void RocketImpact(Vector3 _impactPos)
    {
        attachedRocketModel.SetActive(true);
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
                hitCollider.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, _impactPos,
                explosionRadius, .02f, ForceMode.Impulse); 
            }

            if (hitCollider.GetComponent<EnemyController>())
            {
                hitCollider.GetComponent<EnemyController>().life -= explosionDamage;
                ShowDamage(explosionDamage, _impactPos, hitCollider.GetComponent<EnemyController>(), Color.blue);
            }
        }

    }





}
