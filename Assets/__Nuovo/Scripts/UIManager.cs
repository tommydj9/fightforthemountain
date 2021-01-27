using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text UIAMMO;
    public TMP_Text Health;
    public TMP_Text V_MONEY;

    public Image emptySlot;
    public Image[] ArrayImage;
    public Image[] ArrayChrossair;
    public Image emptyChrosshair;
    public Sprite crosshair;
    public SpriteRenderer actualCrosshair;
    public Image actualCrosshairImage;
 


    /*
    * Creazione Array di immagini
    * Funzione che va a riempire ogni cella dell'array con l'immagine emptySlot (chiamata in Awake)
    * Funzione che riempie con l'arma che abbiamo (funzione in ingresso ha image e puntatore (int))
    * 
    * 
    */
    private void Awake()
    {
        
    }

    public void SetUiAmmo(string ValueS)
    {
        UIAMMO.text = ValueS;
    }
    public void SetUiHealth(string ValueS)
    {
        Health.text = ValueS;
    }
    public void SetUiV_MONEY(string ValueS)
    {
        V_MONEY.text = ValueS;
    }
  

   
    

}
