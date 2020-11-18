using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0,100000)]
    public float life = 100;
    

    public GameObject head;

    public void Die()
    {
        //Aggiungere shader dissolvenza
        Destroy(transform.gameObject, 1f);
        transform.localScale = Vector3.zero; 
    }
}


 
