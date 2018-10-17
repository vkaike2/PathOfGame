using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasico : MonoBehaviour
{

    public float Damage { get; set; }
    public int velHorizontal { get; set; }
    public Rigidbody2D rb { get; set; }
    public int RangeSec { get; set; }

    void Start()
    {
        this.Damage = 1;
        this.velHorizontal = 6;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.RangeSec = 1;
    }
}
