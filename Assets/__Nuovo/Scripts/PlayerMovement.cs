using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 velocity;
    public float gravity = 9.81f;
    public CharacterController characterController;
    public LayerMask Terreno;

    
    void Start()
    {
        
    }

   
    void Update()
    {                       
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");
        Vector3 movimento = transform.right * x + transform.forward * z;
        characterController.Move(movimento * Time.deltaTime * speed);
    }

    /*
        Salto: Seguire la logica del movimento ma sull'asse Y
               Posso saltare SOLO SE il player sta toccando il pavimento
               (aggiungere un collider sui piedi e vedere se sta toccando il pavimento)

                Extra: Abilità doppio salto.
    
     */

}
