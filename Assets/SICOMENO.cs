using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SICOMENO : MonoBehaviour
{
    public void DIFFICOLTA(string Dif)
    {
        SceneManager.LoadScene(Dif);
    }
}