using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowUI : MonoBehaviour
{
    //prendo in reference le varie cose presenti nella UI
    public Text collezionabileTasto;
    public Text viteText;
    public Text timerText;

    [SerializeField] GameObject barraVitaBoss;

    public static float tempo;                                                  //variabile statica che gestisce il tempo
    public static float minuti;                                                 //variabile statica che gestisce i minuti
    public static float secondi;                                                //variabile statica che gestisce i secondi

    public static bool shieldIsActive;
    public static float shieldTimer = 0;
    private GameObject Shield;
    public GameObject playerCollider;
    public Image shieldBar;
    public float shieldValue = 0;

    public static bool staminaIsActive;
    public static float staminaTimer = 0;
    public static bool isTaken;
    public Image staminaBar;
    public float staminaValue = 0;

    void Start()
	{
        Shield = GameObject.FindGameObjectWithTag("Shield");
        Shield.SetActive(false);
	}
    void Update()
    {
        //mostro la quantità di tasti raccolta
        collezionabileTasto.text = Inventory.collezionabile + "";
        viteText.text = Inventory.vite + "";
        if (secondi < 10)                                                             //se i secondi sono minori di 10
            timerText.text = minuti + ":" + "0" + secondi;          //viene visualizzato nell'HUD il tempo se i secondi sono minori di 10
        else
            timerText.text = minuti + ":" + secondi;                    //viene visualizzato nell'HUD il tempo

        ShieldChange(shieldValue);
        StaminaIconChange(staminaValue);

        tempo += Time.deltaTime;                                  //avvio il tempo
        secondi = (int)tempo;                                     //setto i secondi uguali al tempo ma con un casting ad int

        if (tempo >= 60)                                               //se il tempo diventa maggiore di 60
        {
            secondi -= secondi;                                              //i secondi vengono settati a 0
            tempo -= tempo;                                                //il tempo viene settato a 0
            minuti++;                                                 //i minuti salgono di 1
        }

        shieldValue = shieldTimer;

        if (shieldIsActive)                                            //se lo scudo è attivo
        {
            Shield.SetActive(true);
            playerCollider.SetActive(false);
            shieldTimer -= Time.deltaTime * 20;                            //il timer si riduce over time
            if (shieldTimer < 1)                                      //se il timer è minore di uno
            {
                shieldTimer = 0;
                playerCollider.SetActive(true);
                Shield.SetActive(false);
                shieldIsActive = false;                              //lo scudo si disattiva
            }
        }
        void ShieldChange(float shieldValue)
        {
            float amount = (shieldValue/ 100.0f) /** 180.0f / 360*/;
            shieldBar.fillAmount = amount;
            float buttonAngle = amount * 360;
        }

        staminaValue = staminaTimer;

        if (staminaIsActive)                                            //se lo scudo è attivo
        {
            staminaTimer -= Time.deltaTime * 20;                            //il timer si riduce over time
            if (staminaTimer < 1)                                      //se il timer è minore di uno
            {
                staminaTimer = 0;
                ShowUI.isTaken = false;
                staminaIsActive = false;                              //lo scudo si disattiva
            }
        }
        void StaminaIconChange(float staminaValue)
        {
            float amount2 = (staminaValue / 100.0f) /** 180.0f / 360*/;
            staminaBar.fillAmount = amount2;
            float buttonAngle2 = amount2 * 360;
        }
    }

}                                                                          
