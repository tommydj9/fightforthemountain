using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForResumeGame : MonoBehaviour
{
    public GameObject image;
    public GameObject Button;
    public GameObject Button2;
    public playerMovemt movimento;
    public nemico Nemico;
    public GameObject button3;
    public GameObject text5;
    public GameObject text6;
    public GameObject button9;
    public GameObject button10;


    public void Start()
    {
        image.SetActive(false);
        Button.SetActive(false);
        Button2.SetActive(true);
        button3.SetActive(true);
        text5.SetActive(true);
        text6.SetActive(true);
        button9.SetActive(true);
        button10.SetActive(true);
        movimento = this.GetComponent<playerMovemt>();
        Nemico = this.GetComponent<nemico>();
    }
    public void NewGame(string LivelloGioco)
    {


        image.SetActive(true);
        Button.SetActive(true);
        Button2.SetActive(true);
        button3.SetActive(false);
        text5.SetActive(false);
        text6.SetActive(false);
        button9.SetActive(false);
        button10.SetActive(false);
        movimento.enabled = false;
        Nemico.enabled = false;
    }
}
