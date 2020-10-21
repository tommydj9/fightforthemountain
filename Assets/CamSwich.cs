using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwich : MonoBehaviour
{
    [SerializeField]
    Camera firstPCamera;
    [SerializeField]
    Camera thirdPCamera;
    [SerializeField]
    Camera backcamera;
    private bool swichCam = false;
    private bool backCam = false;
    void Start()
    {
        firstPCamera.GetComponent<Camera>().enabled = false;
        thirdPCamera.GetComponent<Camera>().enabled = true;
        backcamera.GetComponent<Camera>().enabled = false;
    }


    void Update()
    {
        if(Input.GetKeyDown("f"))
        {
            swichCam = !swichCam;
            backCam = false;

        }
        if(Input.GetKeyDown("b"))
        {
            swichCam = false;
            backCam = true;
        }
        if(swichCam == true)
        {
            firstPCamera.GetComponent<Camera>().enabled = true;
            thirdPCamera.GetComponent<Camera>().enabled = false;
            backcamera.GetComponent<Camera>().enabled = false;
        }
        else if(backCam == true)
        {
            firstPCamera.GetComponent<Camera>().enabled = false;
            thirdPCamera.GetComponent<Camera>().enabled = false;
            backcamera.GetComponent<Camera>().enabled = true;
        }
        else
        {
            firstPCamera.GetComponent<Camera>().enabled = false;
            thirdPCamera.GetComponent<Camera>().enabled = true;
            backcamera.GetComponent<Camera>().enabled = false;
        }
    }
}
