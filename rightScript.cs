using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rightScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject player;
    public Rigidbody rb;
    public Transform transfrom;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        transfrom = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            player.GetComponent<playerMovemt>().rb.AddForce(60f, 0, 0);
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
