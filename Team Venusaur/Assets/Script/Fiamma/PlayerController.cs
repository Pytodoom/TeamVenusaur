using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    public int maxJump;
    public Rigidbody rb;

    public static bool isDead;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (!isDead)
        {
            PlayerMovement();
        }


        if (Input.GetButtonUp("Jump") && maxJump > 0)
        {
            maxJump--;
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }

        if (rb.velocity == new Vector3(0, 0, 0))
        {
            maxJump = 1;
        }
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized;

        transform.Translate(playerMovement * Speed * Time.deltaTime);
    }
}