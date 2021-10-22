using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//codice che tiene le variabili statiche, come i collezionabili ect
public class Inventory : MonoBehaviour  
{
    public static int collezionabile;
    public static int vite = 3;

    public static void Reset()              //reset delle variabili globali importanti
    {
        collezionabile = 0;
        vite = 3;
        PlayerController.isDead = false;
        Pause.GameIsPaused = false;
        ShowUI.tempo = 0;
        ShowUI.minuti = 0;
        ShowUI.secondi = 0;
    }
}
