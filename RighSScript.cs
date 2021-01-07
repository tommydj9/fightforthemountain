using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RighSScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            Player.transform.Translate(0.2f, 0, 0);
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
}
