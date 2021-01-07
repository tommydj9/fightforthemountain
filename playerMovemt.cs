using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovemt : MonoBehaviour
{
    public Rigidbody rb;
    public Transform MioTransorm;
    public GameObject button;
    public AudioSource Audio;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    // Start is called before the first frame update


    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
        rb = this.GetComponent<Rigidbody>();
        MioTransorm = this.GetComponent<Transform>();
        buttonLeft.SetActive(true);
        buttonRight.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.AddForce(290, 0, 0);
            buttonLeft.SetActive(false);
            buttonRight.SetActive(false);
        }

        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.AddForce(-290, 0, 0);
            buttonLeft.SetActive(false);
            buttonRight.SetActive(false);
        }
    }
}
