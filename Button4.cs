using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4 : MonoBehaviour
{
    public GameObject image;
    public GameObject Button;
    public GameObject Button2;
    public playerMovemt movimento;
    public nemico Nemico;


    public void Start()
    {
       
        movimento = this.GetComponent<playerMovemt>();
        Nemico = this.GetComponent<nemico>();
    }
    public void NewGame(string LivelloGioco)
    {


        image.SetActive(false);
        Button.SetActive(false);
        Button2.SetActive(false);
        movimento.enabled = true;
        Nemico.enabled = true;
    }
}
