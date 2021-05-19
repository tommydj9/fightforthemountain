using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class bUTTONmANAGER : MonoBehaviour 
{
    [Header("References")]
    public PlayerController player;
    public TMP_Text totalCoinsText;

    [Header("Guns References")]
    public GunController sniper;
    public GunController rpg;

    [Header("Values")]
    [SerializeField]
    private int sniperCost = 20;
    [SerializeField]
    private int rpgCost = 100;

    private void Start()
    {
        
        totalCoinsText.text = player.totalCoins.ToString();
    }

    public void BuySniper()
    {
        Debug.Log("v-money click");
        Debug.Log("player.totalCoins" + player.totalCoins + "sniperCost" + sniperCost);

        if (player.totalCoins >= sniperCost)
        {
            player.totalCoins = player.totalCoins - sniperCost;

            totalCoinsText.text = player.totalCoins.ToString();

            if (!sniper.isEquiped && player.idPosition < player.SlotGun.Length)
            {
                Debug.Log("sniper equiped");
                sniper.isEquiped = true;

                player.idPosition++;
                sniper.gunInOrderID = player.idPosition;
                GameObject tempGun = player.SlotGun[sniper.gunInOrderID];
                Animator tempAnimGun = player.animator[sniper.gunInOrderID];
                int indexToChange = 0;

                for (int j = 0; j < player.SlotGun.Length; j++)
                {
                    if (player.SlotGun[j].name == sniper.name)
                    {
                        indexToChange = j;
                    }
                }
                Debug.Log("indexToChange: " + indexToChange);
                player.SlotGun[sniper.gunInOrderID] = player.SlotGun.GetValue(indexToChange) as GameObject;
                player.animator[sniper.gunInOrderID] = player.animator.GetValue(indexToChange) as Animator;
                player.SlotGun[indexToChange] = tempGun;
                player.animator[indexToChange] = tempAnimGun;
            }

        }
    }


    public void BuyRpg()
    {
        Debug.Log("v-money click");
        Debug.Log("player.totalCoins" + player.totalCoins + "sniperCost" + sniperCost);

        if (player.totalCoins >= rpgCost)
        {
            player.totalCoins = player.totalCoins - rpgCost;

            totalCoinsText.text = player.totalCoins.ToString();

            if (!rpg.isEquiped && player.idPosition < player.SlotGun.Length)
            {
                Debug.Log("sniper equiped");
                rpg.isEquiped = true;

                player.idPosition++;
                rpg.gunInOrderID = player.idPosition;
                GameObject tempGun = player.SlotGun[rpg.gunInOrderID];
                Animator tempAnimGun = player.animator[rpg.gunInOrderID];
                int indexToChange = 0;

                for (int j = 0; j < player.SlotGun.Length; j++)
                {
                    if (player.SlotGun[j].name == rpg.name)
                    {
                        indexToChange = j;
                    }
                }
                Debug.Log("indexToChange: " + indexToChange);
                player.SlotGun[rpg.gunInOrderID] = player.SlotGun.GetValue(indexToChange) as GameObject;
                player.animator[rpg.gunInOrderID] = player.animator.GetValue(indexToChange) as Animator;
                player.SlotGun[indexToChange] = tempGun;
                player.animator[indexToChange] = tempAnimGun;
            }

        }
    }

}

