using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform playerTransform;
    public float mouseSensibilty = 6f;
    public float rotationX;
    public float rotationY;
    private float mouseX;
    private float mouseY;
    

    
    void Start()
    {
        
    }

  
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensibilty;
        mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensibilty;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);
        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        playerTransform.Rotate(mouseX * Vector3.up);
    }
}
