using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public float time;
    public GameObject start;
    public GameObject end;
    public Material red;
    public Material green;

    public Ease playerArrivesEase;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start.transform.position;
        transform.GetComponent<Renderer>().material = red;
        Move();

        

        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void Move()
    {
        transform.DOMove(end.transform.position, time).SetEase(playerArrivesEase).OnComplete(()=> transform.GetComponent<Renderer>().material = green);
        
    }

}
