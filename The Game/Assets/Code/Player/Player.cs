using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb { get; set; }
    public int velHorizontal;
    public int velVertical;
    public float atkSpeed;
    public float Hp;
    public float cdwDmage;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
