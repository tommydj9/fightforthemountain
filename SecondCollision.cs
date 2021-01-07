using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondCollision : MonoBehaviour
{
    public GameObject Button;
    public GameObject Button2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "prova")
        {
            Debug.Log("va");
            
            Button.SetActive(false);
            Button2.SetActive(false);


        }




    }
}
