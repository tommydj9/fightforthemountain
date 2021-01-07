using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ScriptMobile : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    
    // Start is called before the first frame update
    void Start()
    {

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
        if (isPressed)
        {
            
        }
        SceneManager.LoadScene("ScenaDiGioco");
    }

}