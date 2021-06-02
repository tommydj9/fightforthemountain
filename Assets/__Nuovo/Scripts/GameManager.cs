using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager instance {
        get {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    public void reload()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void quit()
    {
        Application.Quit();
    }
}
