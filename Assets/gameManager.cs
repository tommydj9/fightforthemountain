using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public bool giocoFinito;
   
    
    void Start()
    {
        
    }



    public void GameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }


}
