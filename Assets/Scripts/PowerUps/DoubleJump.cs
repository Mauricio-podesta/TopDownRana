using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PowerUps
{
    [SerializeField] bool firstjump;
    [SerializeField] bool puedesaltar = false;
    void Start()
    {
        check = false;
        PlayerRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        PowerUp();
    }
    public override void PowerUp()
    {
        if (Input.GetKeyUp(KeyCode.Space) && check)
        {
            firstjump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && firstjump)
        {
            PlayerRB.AddForce(Vector2.up * Jumpforce * 2f, ForceMode2D.Impulse);
            firstjump = false;
            check = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            puedesaltar = true;
            check = true;
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            firstjump = false;
        if (puedesaltar)
            check = true;
    }
}
