using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float life = 100;
    private float maxLife;

    public Animator[] animator;
    public Animator CurrentAnimator;

    public float speed = 10f;
    private Vector3 velocity;
    public float gravity = -9.81f;
    public bool isTouch;
    public float groundCheckerRadius = 0.2f;
    public float forzaSalto;
    public CharacterController characterController;
    public LayerMask Terreno;
    public Transform groundChecker;

    public int maxJumps = 2;
    private int jumpCounter = 0;
    public GameObject[] SlotGun;
    public int SlotGunIndex;
    public UIManager UImanager;
    public GunController gun;

    [Header("Camera Effects")]
    public CameraBloodEffect cameraBloodEffect;


    private void Awake()
    {
        Cursor.visible = false;
        ChangeGun(0);
        maxLife = life;

        UImanager.crosshair = SlotGun[SlotGunIndex]
            .GetComponent<GunController>().CrosshairImage;
        UImanager.actualCrosshairImage.sprite = UImanager.crosshair;

        for (int i = 1; i < UImanager.ArrayImage.Length; i++)
        {
            UImanager.ArrayImage[i].enabled = false;
        }
        

    }



    void Update()
    {
        //Salto
        isTouch = Physics.CheckSphere(groundChecker.position, groundCheckerRadius, Terreno);

        if (isTouch && velocity.y < 0)
        {

            velocity.y = -1;
            jumpCounter = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCounter < maxJumps)
        {
            velocity.y = Mathf.Sqrt(forzaSalto * gravity * -1);
            jumpCounter++;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movimento = transform.right * x + transform.forward * z;
        characterController.Move(movimento * Time.deltaTime * speed);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        #region metodo pro

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //    ChangeGun(SlotGunIndex < SlotGun.Length -1 ? SlotGunIndex++ : 0);

        //else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //    ChangeGun(SlotGunIndex > 0 ? SlotGunIndex-- : SlotGun.Length -1 );

        #endregion


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SlotGunIndex++;
            
            


            if (SlotGunIndex > SlotGun.Length - 1)
            {
                SlotGunIndex = 0;
            }

            

            ChangeGun(SlotGunIndex);
            ChangeImage(UImanager.emptySlot);
     

            Debug.Log(SlotGun[SlotGunIndex]
            .GetComponent<GunController>().CrosshairImage.name);

            UImanager.crosshair = SlotGun[SlotGunIndex]
            .GetComponent<GunController>().CrosshairImage;
            
            UImanager.actualCrosshairImage.sprite = UImanager.crosshair;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SlotGunIndex--;
            

            if (SlotGunIndex < 0)
            {
                SlotGunIndex = SlotGun.Length - 1;
            }

           

            ChangeGun(SlotGunIndex);
            ChangeImage(UImanager.emptySlot);
            //ChangeCrosshair(UImanager.emptyChrosshair);
            UImanager.crosshair = SlotGun[SlotGunIndex]
            .GetComponent<GunController>().CrosshairImage;
            UImanager.actualCrosshairImage.sprite = UImanager.crosshair;

        }

    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        if (life <= 0)
        {
           
            Death();

        }
    }

    public void Death()
    {
        //mettere animazione
        //mettere suono
        //mettere menù ricomincia
        //Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DamageCollider>())
        {
            TakeDamage(other.GetComponent<DamageCollider>().damage);
            
        }
    }

    public void ChangeGun(int  _SlotGunIndex)
    {
       
        for (int i = 0; i < SlotGun.Length; i++)
        {
            SlotGun[i].SetActive(false);
            
        }

        SlotGun[_SlotGunIndex].SetActive(true);
        SlotGunIndex = _SlotGunIndex;
        CurrentAnimator = animator[SlotGunIndex];
        GunController currecntGun = SlotGun[_SlotGunIndex].GetComponent<GunController>();
        UImanager.SetUiAmmo(currecntGun.currentCartdrigeSize.ToString());

    }

    public void ChangeImage(Image _emptySlot )
    {
        
        for (int i = 0; i < UImanager.ArrayImage.Length; i++)
        {

            #region esempo logFormat
            //Debug.LogFormat("Oggetto colpito {0} --> Oggetto toccato {1}", hitObject.name, touchedObj.name);
            #endregion

            //gun.gunImageSelected.enabled = false;

            if (i == SlotGunIndex)
            {
                UImanager.ArrayImage[i].enabled = true;
            }
            else
            {
                UImanager.ArrayImage[i].enabled = false;
            }


        }
     

    }

    public void ChangeCrosshair(Image _emptyChrosshair)
    {
        for (int i = 0; i < UImanager.ArrayChrossair.Length; i++)
        {
            if (i == SlotGunIndex)
            {
                UImanager.ArrayChrossair[i].enabled = true;
                transform.localScale = Vector3.zero;
            }
            else
            {
                UImanager.ArrayChrossair[i].enabled = false;
            }
        }
    }

    public void ReceiveDamage(float _damage)
    {
        life -= _damage;

        cameraBloodEffect.bloodAmount += (maxLife - life) / 100;
        cameraBloodEffect.minBloodAmount += (maxLife - life)/500; 
        Debug.Log("Life: " + life);



        if (life <= 0)
        {
            //TODO: GameOver
        }

    }



}
