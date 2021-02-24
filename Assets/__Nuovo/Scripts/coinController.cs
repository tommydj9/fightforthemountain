using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinController : MonoBehaviour
{
    [SerializeField]
    float value;

    public ParticleSystem coinAnimation_UI;


    private void PlayCoinAnimation_UI()
    {
        coinAnimation_UI.Stop();
        coinAnimation_UI.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            other.GetComponent<PlayerController>().UpdateCoinsValue(value);
            other.GetComponent<PlayerController>().UImanager.V_MONEY.text += value; 
            PlayCoinAnimation_UI();
            Destroy(transform.gameObject);

            // v-money += value -> 10 (valore intero)
            // v-moneyUI.text = v-money.toString (TMP)
        }
    }

    
}
