using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nemico : MonoBehaviour
{
    public Transform bersaglio;
    public float speed;
    public Rigidbody rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        speed = 5f;
    }

    
    void Update()
    {
        Vector3 doveVado = Vector3.MoveTowards(transform.position, bersaglio.position, speed * Time.deltaTime);

        rb.MovePosition(doveVado);
        transform.LookAt(bersaglio);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "umano")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        
         
        
    }
}
