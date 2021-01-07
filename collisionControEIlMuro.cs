using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionControEIlMuro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.collider.tag == "obstacol")
        {
            Destroy(gameObject);
        }
    }
}
