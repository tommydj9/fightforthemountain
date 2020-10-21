using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gitrandola : MonoBehaviour
{
    public Transform Corpo;
    public float MouseSensibility = 15f;
    public float rotazioneX = 0f;
    public float rotazioneY = 0f;
    public bool cursor = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        float XdelMouse = Input.GetAxis("Mouse X") * Time.deltaTime * MouseSensibility;
        float YdelMouse = Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSensibility;
        Corpo.Rotate(Vector3.up * XdelMouse );
        rotazioneX = rotazioneX - YdelMouse;
        rotazioneY = rotazioneY - XdelMouse;
        rotazioneX = Mathf.Clamp(rotazioneX, -90f, 90f);
        rotazioneY = Mathf.Clamp(rotazioneX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotazioneX, 0f, 0f);
    }
}
