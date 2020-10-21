using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{
    public Text moneyText;
    public static int moneyAmount;
    int IsRifleSold;
    public GameObject rifle;

    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
        IsRifleSold = PlayerPrefs.GetInt("IsRifleSold");

        if (IsRifleSold == 1)
            rifle.SetActive(true);
        else
            rifle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + moneyAmount.ToString() + "$";
    }

    public void gotoShop()
    {
        PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
        SceneManager.LoadScene("ShopScene");
    }
}
 
