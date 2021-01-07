using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class bUTTONmANAGER : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{ 
    public GameObject button6;
    public bool isPressed;
    void Start()
    {

        
        button6.SetActive(false);


    }

    public void ExitGame()
    {

        if (isPressed)
        {


        }
        Application.Quit();
     
    }
    public void ItemShop(string PassBattaglia)
    {

        SceneManager.LoadScene(PassBattaglia);

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

        SceneManager.LoadScene("ScenaDiGioco");


    }


}

