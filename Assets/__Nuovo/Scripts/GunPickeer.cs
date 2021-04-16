using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickeer : MonoBehaviour
{
    public int gunId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {

            if (other.GetComponent<PlayerController>().SlotGun[gunId].GetComponent<GunController>().isEquiped == false)
            {
                other.GetComponent<PlayerController>().SlotGun[gunId]
             .GetComponent<GunController>().isEquiped = true;

                other.GetComponent<PlayerController>().idPosition++;
            }
            Destroy(gameObject);
        }
    }
}
