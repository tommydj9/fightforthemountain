using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Collision : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Button;
    public GameObject Text;
    public playerMovemt movimento;
    public GameObject ScoreText2;
    public GameObject Score3;
    public nemico Nemico;
    public GameObject textScore;
    public GameObject ButtonRight;
    public GameObject ButtonLeft;
    public rightScript right;
    public ScriptLeft left;
    // Start is called before the first frame update
    void Start()
    {
        movimento = this.GetComponent<playerMovemt>();
        Nemico = this.GetComponent<nemico>();
        right = this.GetComponent<rightScript>();
        left = this.GetComponent<ScriptLeft>();
        Panel.SetActive(false);
        Text.SetActive(false);
        ScoreText2.SetActive(false);
        Score3.SetActive(false);
        Button.SetActive(false);
        textScore.SetActive(true);
        ButtonRight.SetActive(true);
        ButtonLeft.SetActive(true);
        right.enabled = true;
        left.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "obstacol")
        {
            Debug.Log("FUNZIONA");
            Panel.SetActive(true);
            Text.SetActive(true);
            Button.SetActive(true);
            ScoreText2.SetActive(true);
            Score3.SetActive(true);
            textScore.SetActive(false);
            movimento.enabled = false;
            Nemico.enabled = false;
            ButtonRight.SetActive(false);
            ButtonLeft.SetActive(false);
            right.enabled = false;
            left.enabled = false;


        }

        

            
    }

    

}
