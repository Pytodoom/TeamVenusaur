using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //Fire rate Sparo a 2 millesimi di secondo e fire rate corrente inizializzato a 0
    [SerializeField]
    private float fireRate = .2f, fireRateCurrent = 0;

    //Posizione della camera per far partire il RayCast del punto di sparo
    [SerializeField]
    private Camera cam;

    //Posizione della posizione di sparo per far apparire il muzzle dell'arma
    [SerializeField]
    private Transform shootPos;

    //Danno di sparo e range
    [SerializeField]
    private float dmg = 1, range = 200;
    private void LateUpdate()
    {
        //Se il timer corrente del firerate ha superato il timer di sparo
        if (fireRateCurrent >= fireRate)
        {
            //Controllo se sto premendo il pulsante di sparo(tasto sinistro del mouse)
            if (Input.GetKey(KeyCode.Mouse0))
            {
                //Chiamo metodo per sparare
                Shoot();
                //Istanzio lo sparo
                //Azzero il fireRate così da poter rieseguire questo codice
                fireRateCurrent = 0;
            }
        }
        //Altrimenti incremento il fireRateCurrent
        else fireRateCurrent += Time.deltaTime;
    }

    //Metodo per sparare
    private void Shoot()
    {
        //Faccio apparire l'effetto particellare del muzzle flash dell'arma
        GameObject muzzle = ObjectPooling.inst.SpawnObjectFromPool("Muzzle", shootPos.position, Quaternion.LookRotation(shootPos.forward));
        //Inizializzo un istanza di tipo raycast hit per memorizzare le informazioni di cosa toccherà il ray
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) 
        {
            //Ottengo la componente IDamageable del collisore, se ce l'ha posso fargli danno altrimenti no
            IDamageable damageable = hit.collider.GetComponent<IDamageable>();

            //Se possiede la componente IDamageable
            if (damageable != null)
            {
                //Chiamo la sua funziona di damage e gli passo il mio danno
                damageable.Damage(dmg); 
            }

            //Creo l'effetto particellare dell'impatto


        }

        //Coroutine che lo riaggiunge alla sua pool chiamato dopo 2 millesimi di secondo
        StartCoroutine(IReAddToPool(muzzle, .2f, "Muzzle"));
        //Faccio apparire l'effetto particellare d'impatto dell'arma
        GameObject impact = ObjectPooling.inst.SpawnObjectFromPool("Impact", hit.point, Quaternion.LookRotation(hit.normal));
        //Coroutine che lo riaggiunge alla sua pool chiamato dopo 2 millesimi di secondo
        StartCoroutine(IReAddToPool(impact, .2f, "Impact"));
    }

    private IEnumerator IReAddToPool(GameObject gb, float time, string name)
    {
        //Aspetto il tempo passato per parametro
        yield return new WaitForSeconds(time);
        //Lo ri aggiungo dopo alla sua pool
        ObjectPooling.inst.ReAddObjectToPool(name, gb);
    }         
}
