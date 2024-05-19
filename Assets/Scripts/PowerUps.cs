using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    [SerializeField] public float Jumpforce = 5;
    [SerializeField] public bool check = true;

    public abstract void PowerUp();
}
