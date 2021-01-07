using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MobilePause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
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
    // Start is called before the first frame update
    void Start()
    {
        movimento = this.GetComponent<playerMovemt>();
        Nemico = this.GetComponent<nemico>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }

    public void NewGame(string LivelloGioco)
    {
        image.SetActive(false);
        Button.SetActive(false);
        Button2.SetActive(false);
        movimento.enabled = true;
        Nemico.enabled = true;

        if (isPressed)
        {
            SceneManager.LoadScene("ScenaDiGioco");
        }
    }


}
