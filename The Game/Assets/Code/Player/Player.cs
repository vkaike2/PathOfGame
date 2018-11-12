using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public int velocidadeMoviemnto;
    public int impulsoPulo;
    public float atkSpeed;
    public float Hp;
    public float cdwDmage;
    public float dmg;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
