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
    public float maxRunSpeed = 5;
    public float velRatio = 3.5f;
    public float lerpForce = 3;
    float currentSpeed = 0;
    float maxSpeed;

    public NavMeshAgent agent;
    public NavMeshObstacle obstacle;

    public Transform positionReferencePlayer;

    public bool playerFound = false;


    public float distanceToAttack = 1;
    float playerDistance;

    private void Start()
    {
        obstacle = GetComponent<NavMeshObstacle>();
    }


    public GameObject head;

    public void Die()
    {
        //Aggiungere shader dissolvenza
        //Destroy(transform.gameObject, 1f);
        //transform.localScale = Vector3.zero; 
        animator.SetTrigger("death");
        agent.speed = 0;
    }

    public void Update()
    {

        if (life < 80)
        {
            maxSpeed = maxRunSpeed;
        }
        else
        {
            maxSpeed = maxWalkSpeed;
        }

        animator.SetFloat("speed", currentSpeed);
        
        if (life < 0)
        {
            Die();
        }

        if (playerFound)
        {

            if (!agent.hasPath)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * lerpForce);
            }
            else
            {
                float velocity = Vector3.Project(agent.velocity, this.transform.forward).magnitude;
                currentSpeed = Mathf.Lerp(currentSpeed, velocity / velRatio, Time.deltaTime * lerpForce);
                agent.speed = maxSpeed;
            }

            agent.destination = positionReferencePlayer.position;
            playerDistance = (positionReferencePlayer.position - transform.position).magnitude;
            animator.SetFloat("distance", playerDistance);
        }

        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            Vector3 distanceVector = (transform.position - positionReferencePlayer.position); 
        }

        if (Input.GetKey(KeyCode.N))
        {
            playerFound = !playerFound;
        }

    }
}


 
