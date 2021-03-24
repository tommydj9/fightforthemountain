using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    public ParticleSystem coinAnimation_UI;

    [SerializeField]
    float value;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController player = other.GetComponent<PlayerController>();

            player.UpdateCoinsValue(value);
            player.UImanager.V_MONEY.text = player.totalCoins.ToString();
            Destroy(transform.gameObject);
            player.PlayCoinAnimation_UI();

            // v-money += value -> 10 (valore intero)
            // v-moneyUI.text = v-money.toString (TMP)
        }
    }

    
}
