using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MOVEMENT : MonoBehaviour

{
    public float speed = 10f;
    public CharacterController controller;
    public float Gravity;
    public Vector3 Caduta;
    public bool isTouch;
    public Transform piedi;
    public LayerMask terreno;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
        Gravity = -10f;
    }


    void Update()
    {
        isTouch = Physics.CheckSphere(piedi.transform.position, 0.4f, terreno);

        if (isTouch == true && Caduta.y < 0)
        {
            Caduta.y = 0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 Movimento = transform.right * x + transform.forward * z;
        controller.Move(Movimento * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            Caduta.y = 20f;
        }

        Caduta.y += (Gravity * Time.deltaTime);
        controller.Move(Caduta * Time.deltaTime);


        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 10f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            Caduta.y = 40f;
        }
        else
        {
            Caduta.y = -10f;
        }

    }
}
       
    
