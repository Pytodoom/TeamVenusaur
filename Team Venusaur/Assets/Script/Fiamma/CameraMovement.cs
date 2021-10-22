using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public float mouseSensitive = 100f;                                                 //sensibilità del mouse
	public Transform Player;                                                        //riferimeto al player
	float xRotation = 0f;                                                               //per settare tutto.

	// Use this for initialization
	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;                                       //quando mettiamo play il cursore non si vede
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		float mouseX = Input.GetAxis("MouseX") * mouseSensitive * Time.deltaTime;      //creiamo una variabile che capisca come ci si muove rispetto al tempo ed alla variabile X
		float mouseY = Input.GetAxis("MouseY") * mouseSensitive * Time.deltaTime;      //creiamo una variabile che capisca come ci si muove rispetto al tempo ed alla variabile Y
		xRotation -= mouseY;                                                            //xRotation serve ad invertire le assi di rotazione in modo che siano corrette per il nostro occhio.
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);                                  //mettiamo un limite (mettere  -0f e 20f e spostare la telecamera per rendere in 3° persona.)
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);                  //su che assi deve creare la rotazione. euler converte in gradi.
		Player.Rotate(Vector3.up * mouseX);                                         //fa capire quando far ruotare il corpo del giocatore insieme al mouse.
	}
}
