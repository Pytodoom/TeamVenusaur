using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{

    //Metodo di damage che avranno tutti i componenti che possono ricevere danno
    void Damage(float dmg);

}