using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int velHorizontal { get; set; }
    public int velVertical { get; set; }
    public Rigidbody2D rb { get; set; }
    public float atkSpeed { get; set; }
    public float Hp { get; set; }

    void Start()
    {
        this.velHorizontal = 5;
        this.velVertical = 1000;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.atkSpeed = 2;
        this.Hp = 2;
    }
}
