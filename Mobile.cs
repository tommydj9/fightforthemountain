using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject button11;
    public GameObject button12;
    public GameObject Panel;
    public GameObject Text;
    public playerMovemt Movemnt;
    public nemico nemico;
    bool isPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        button11.SetActive(true);
        button12.SetActive(true);
        Panel.SetActive(true);
        Text.SetActive(true);
        nemico.enabled = false;
        Movemnt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void NewGame(string LivelloGioco)
    {
        button11.SetActive(false);
        button12.SetActive(false);
        Panel.SetActive(false);
        Text.SetActive(false);
        nemico.enabled = true;
        Movemnt.enabled = true;

        if (isPressed)
        {
           
        }
       
    }
}
