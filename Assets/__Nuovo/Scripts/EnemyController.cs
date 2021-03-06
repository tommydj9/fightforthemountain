﻿using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public Animator animator;
    public EnemySpawner spawner;

    [Range(0,1000)]
    public float life = 250;
    public float maxWalkSpeed = 2.5f;
    public float maxRunSpeed = 5f;
    public float maxSpeed;
    public float currentSpeed;
    public float velocityRatio;
    public float lerpForce = 1;
    public float distance;
    public float probabilitySpawn;
    public GameObject prefabEnemy;


    public NavMeshAgent agent;
    public Transform positionReferencePlayer;
   

    public bool playerFound = false;


    public GameObject head;
    public int vmoney;
    public UIManager uimanager;
    public GameObject coinController;

    private bool isDead = false;

    public void Die()
    {
        
        if (!isDead)
        {
            isDead = true;
            Instantiate(coinController, transform.position, Quaternion.identity);
            spawner.enemiesKilled++;
        }

        animator.SetTrigger("death");
        agent.velocity = Vector3.zero;
        
        Destroy(gameObject, 3.5f);



        //Aggiungere shader dissolvenza
        //transform.localScale = Vector3.zero;
    }

    public void Update()
    {
        
        if (life < 50)
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
            Die();
        }

    }
    
}


 
