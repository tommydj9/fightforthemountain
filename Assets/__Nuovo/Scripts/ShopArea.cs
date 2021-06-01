using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopArea : MonoBehaviour
{
    private PlayerController player;
    public Image uiShop;
    public Image shopPopUp;
    private bool isActiveshop;

    private void Start()
    {
        uiShop.enabled = false;
        shopPopUp.enabled = false;
        uiShop.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            shopPopUp.enabled = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Debug.Log("isentryShop");
            
            player = other.GetComponent<PlayerController>();
            if (Input.GetKey(KeyCode.E))
            {
                uiShop.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                shopPopUp.enabled = false;

                isActiveshop = true;
                
                uiShop.enabled = true;
                

                player.canMove = false;
            }

            if (Input.GetKey(KeyCode.Escape) && isActiveshop == true) //Con ESC come tasto per uscire CursorLockMode va in Lock e poi subito dopo in None
            {
                Cursor.lockState = CursorLockMode.Locked;
                isActiveshop = false;
                player.canMove = true;
                uiShop.enabled = false;
                uiShop.gameObject.SetActive(false);
                shopPopUp.enabled = true;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        shopPopUp.enabled = false;
        isActiveshop = false;
        player.canMove = true;
    }
}
