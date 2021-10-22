using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    //Vita
    [SerializeField]
    private float health;

    //Metodo per ricevere danno
    public void Damage(float dmg)
    {
        //Diminuisco la vita, se è maggiore di zero
        health -= dmg;

        //Controllo se la vita è sotto o uguale a zero, e in caso chiamo il metodo di morte
        if (health <= 0)
            Death();

    }

    //Metodo di morte
    private void Death() 
    {
        //Disattivo il gameObject
        gameObject.SetActive(false);
        //ObjectPooling.inst.ReAddObjectFromPool("Zombies", gameObject);
    }
}
