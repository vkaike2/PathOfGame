﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasico : MonoBehaviour
{

    public float Damage;
    public int velHorizontal;
    public int RangeSec;
    public Rigidbody2D rb { get; set; }

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
