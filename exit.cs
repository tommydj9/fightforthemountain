using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class exit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject button6;
    public bool isPressed;
    public void NewGame(string LivelloGioco)
    {

        SceneManager.LoadScene(LivelloGioco);
        button6.SetActive(false);

    }

    public void ExitGame()
    {    
        if (isPressed)
        {
            Application.Quit();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void ItemShop(string PassBattaglia)
    {

        SceneManager.LoadScene(PassBattaglia);

    }
}
