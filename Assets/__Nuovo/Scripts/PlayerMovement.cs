using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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

    
    void Start()
    {}

   
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


        //Movimento
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        Vector3 movimento = transform.right * x + transform.forward * z;
        characterController.Move(movimento * Time.deltaTime * speed);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    /*
        Salto: Seguire la logica del movimento ma sull'asse Y
               Posso saltare SOLO SE il player sta toccando il pavimento
               (aggiungere un collider sui piedi e vedere se sta toccando il pavimento)

                Extra: Abilità doppio salto.
    
     */

    

}
