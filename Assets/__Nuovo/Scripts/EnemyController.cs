using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Animator animator;

    [Range(0,1000)]
    public float life = 1000;
    public float maxWalkSpeed = 2.5f;
    public float maxRunSpeed = 5f;
    public float maxSpeed;
    public float currentSpeed;
    public float velocityRatio;
    public float lerpForce = 1;
    public float distance;


    public NavMeshAgent agent;
    public Transform positionReferencePlayer;

    public bool playerFound = false;


    public GameObject head;

    public void Die()
    {


        //Aggiungere shader dissolvenza
        Destroy(transform.gameObject, 1f);
        transform.localScale = Vector3.zero;

    }

    public void Update()
    {
        

        if (Input.GetKey(KeyCode.N))
        {
            playerFound = true;
        }


        if (life < 950)
        {
            maxSpeed = maxRunSpeed;
        }
        else
        {
            maxSpeed = maxWalkSpeed;
        }

        if (playerFound == true)
        {

            agent.destination = positionReferencePlayer.position;

            if (agent.hasPath == false) //L'agent ha il percorso verso la destinazione?
            {
                currentSpeed = Mathf.Lerp(maxSpeed, 0f, Time.deltaTime * lerpForce);

            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * lerpForce);

            }
            animator.SetFloat("speed", currentSpeed);


            
        }

        distance = (positionReferencePlayer.position - transform.position).magnitude;
        animator.SetFloat("distance", distance);

        if (life <= 0f)
        {
            animator.SetTrigger("death");
            agent.speed = 0f;
            Destroy(transform.gameObject, 3.5f);
            
        }

    }
    
}


 
