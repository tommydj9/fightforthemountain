using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAnimatorController : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator animator;

    public float velRatio = 3.5f;
    //public float rotRatio = 180;
    public float lerpForce = 3;

    float currentForward = 0;
    //float currentRotation = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {

        if (!agent.hasPath)
        {
            currentForward = Mathf.Lerp(currentForward, 0, Time.deltaTime * lerpForce);
            //currentRotation = Mathf.Lerp(currentRotation, 0, Time.deltaTime * lerpForce);
        }
        else
        {

            float velocity = Vector3.Project(agent.velocity, this.transform.forward).magnitude;

            //float angle = Vector3.Angle(this.transform.forward, agent.velocity);

            //Debug.LogFormat("Current: vel:{0} angle:{1}", velocity, angle);

            currentForward = Mathf.Lerp(currentForward, velocity / velRatio, Time.deltaTime * lerpForce);
            //currentRotation = Mathf.Lerp(currentRotation, angle / rotRatio, Time.deltaTime * lerpForce);
        }

        animator.SetFloat("forward", currentForward);
        //animator.SetFloat("rotate", currentRotation);

    }
}
