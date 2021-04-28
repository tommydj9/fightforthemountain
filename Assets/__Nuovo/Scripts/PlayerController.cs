using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    public float life = 100;
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
    public GunController currentGun;
    public int idPosition;
    public Slider healthBar;

    [Header("Camera Effects")]
    public CameraBloodEffect cameraBloodEffect;
    public ParticleSystem coinAnimation_UI;

    [HideInInspector]
    public float totalCoins;

    

    private void Awake()
    {
       

        Cursor.lockState = CursorLockMode.Locked;

        healthBar.value = 1;

        Cursor.visible = false;
        ChangeGun(0,true);
        maxLife = life;
        totalCoins = 0;

        UImanager.crosshair = SlotGun[SlotGunIndex].GetComponent<GunController>().CrosshairImage;
        UImanager.actualCrosshairImage.sprite = UImanager.crosshair;

        for (int i = 1; i < UImanager.ArrayImage.Length; i++)
        {
            UImanager.ArrayImage[i].enabled = false;
        }


        coinAnimation_UI.transform.gameObject.SetActive(false);


    }



    void Update()
    {

        //CONVERTIRE DA UPDATE AD EVENTO
        for (int i = 0; i < SlotGun.Length; i++)
        {
            Debug.Log("SlotGun test: " + i);
            SlotGun[i].GetComponent<GunController>().UpdateEquippedGun();
        }

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

            ChangeGun(SlotGunIndex,true);
            ChangeImage(UImanager.emptySlot);     

            Debug.Log(SlotGun[SlotGunIndex].GetComponent<GunController>().CrosshairImage.name);

            UImanager.crosshair = SlotGun[SlotGunIndex].GetComponent<GunController>().CrosshairImage;
            
            UImanager.actualCrosshairImage.sprite = UImanager.crosshair;

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SlotGunIndex--;
            

            if (SlotGunIndex < 0)
            {
                SlotGunIndex = SlotGun.Length - 1;
            }

           

            ChangeGun(SlotGunIndex,false);
            ChangeImage(UImanager.emptySlot);
            //ChangeCrosshair(UImanager.emptyChrosshair);
            UImanager.crosshair = SlotGun[SlotGunIndex].GetComponent<GunController>().CrosshairImage;
            UImanager.actualCrosshairImage.sprite = UImanager.crosshair;
        }

    }

    public void TakeDamage(float _damage)
    {
        life -= _damage;
        healthBar.value = life / 90;
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

    public void ChangeGun(int _SlotGunIndex, bool _changeUp)
    {
        if (_SlotGunIndex >= SlotGun.Length)
        {
            _SlotGunIndex = 0;
        }

        SlotGunIndex = _SlotGunIndex;

        if (SlotGun[SlotGunIndex].GetComponent<GunController>().isEquiped == true)
        {
            for (int i = 0; i < SlotGun.Length; i++)
            {
                SlotGun[i].SetActive(false);
            }

            SlotGun[SlotGunIndex].SetActive(true);
            CurrentAnimator = animator[SlotGunIndex];
            currentGun = SlotGun[SlotGunIndex].GetComponent<GunController>();
            UImanager.SetUiAmmo(currentGun.currentCartdrigeSize.ToString());
        }
        else
        {
            if (_changeUp == true)
            {
                ChangeGun(SlotGunIndex + 1, _changeUp);
            }
            else
            {
                ChangeGun(SlotGunIndex - 1, _changeUp);
            }
        }
    }

    public void ChangeImage(Image _emptySlot)
    {
        
        for (int i = 0; i < UImanager.ArrayImage.Length; i++)
        {

            #region esempio logFormat
            //Debug.LogFormat("Oggetto colpito {0} --> Oggetto toccato {1}", hitObject.name, touchedObj.name);
            #endregion

            //gun.gunImageSelected.enabled = false;

            if (i == currentGun.gunInOrderID)
            {
                UImanager.ArrayImage[i].enabled = true;
            }
            else
            {
                UImanager.ArrayImage[i].enabled = false;
            }

        }

    }

    public void UpdateCoinsValue(float _value)
    {
        totalCoins += _value;
    }

    public void ChangeCrosshair(Image _emptyChrosshair)
    {
        for (int i = 0; i < UImanager.ArrayChrossair.Length; i++)
        {
            if (i == SlotGunIndex)
            {
                UImanager.ArrayChrossair[i].enabled = true;
                
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

    public void PlayCoinAnimation_UI()
    {
        coinAnimation_UI.gameObject.SetActive(false);
        coinAnimation_UI.gameObject.SetActive(true);
    }



    public void Heal(int value)
    {
        life += value;
        healthBar.value = life / 90;
        life = Mathf.Clamp(life, 0, maxLife);
    }


    public void MaxHeal()
    {
        life = maxLife;
        healthBar.value = life / 90;
    }


    public void PoisonHeal(int value)
    {
        life -= value;
        healthBar.value = life / 90;

    }

}
