using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject FirstButton, OptionsFirstButton, OptionsClosedButton, CreditsFirstButton, CreditsClosedButton;         //prendo in reference dei bottoni presenti nel menu
    bool mouseUsed = default;                                                       //creo una bool che fa capire se il mouse è in uso
    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);                            //nessun gameobject è selezionato dall'event system 
        EventSystem.current.SetSelectedGameObject(FirstButton);                     //il gameobject "FirstButton" è selezionato dall'event system 
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");                          //assegno ad una variabile float il valore dell'asse orizzontale
        float vertical = Input.GetAxisRaw("Vertical");                              //assegno ad una variabile float il valore dell'asse verticale

        if (ControllerCheck.controllerPlugged == true)                              //se il controller è collegato
        {
            if (horizontal != 0 && mouseUsed == true|| vertical != 0 && mouseUsed == true) //se il valore delle assi è diverso da 0 il mouse è stato utilizzato
            {
                mouseUsed = false;                                                  //disabilito la variabile per evitare che l'event system continua ad assegnare sempre un tasto e non permette al controller di muoversi
                EventSystem.current.SetSelectedGameObject(FirstButton);             //fai selezionare all'event system il primo tasto
            }
            Cursor.lockState = CursorLockMode.Locked;                               //blocca il mouse e rendilo invisibile
            Cursor.visible = false;
        }
        else                                                                        //sennò
        {
            mouseUsed = true;                                                       //il mouse è in uso
            EventSystem.current.SetSelectedGameObject(null);                        //nessun tasto viene utilizzato, quindi l'event system non ne sta selezionando nessuno
            Cursor.lockState = CursorLockMode.None;                                 //rende il mouse visibile e libero
            Cursor.visible = true;
        }
    }

    public void LoadLevel()
    {
        Inventory.Reset();
        StartCoroutine("wait");
    }

    public void Loadmenu()
    {
        Inventory.Reset();
        SceneManager.LoadScene("StartScene");                                    //si passa al livello1
    }
    public void QuitGame()
    {
        Inventory.Reset();
        Application.Quit();                                                 //viene chiuso il gioco
    }
    public void BackOptions()
    {
        EventSystem.current.SetSelectedGameObject(OptionsClosedButton);     //quando clicchi il tasto indietro delle opzioni, l'event system seleziona il tasto opzioni nel pannello del menu principale
    }

    public void BackCredits()
    {
        EventSystem.current.SetSelectedGameObject(CreditsClosedButton);     //quando clicchi il tasto indietro delle opzioni, l'event system seleziona il tasto opzioni nel pannello del menu principale
    }

    public void Options()
    {
        EventSystem.current.SetSelectedGameObject(OptionsFirstButton);      //quando clicchi il tasto opzioni, l'event system seleziona il tasto indietro nel pannello delle opzioni
    }

    public void Credits()
    {
        EventSystem.current.SetSelectedGameObject(CreditsFirstButton);      //quando clicchi il tasto opzioni, l'event system seleziona il tasto indietro nel pannello delle opzioni
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("LivelloFiamma");                                    //si passa al livello1
    }
}
