using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hillock : MonoBehaviour {

    public Rigidbody2D rb { get; set; }
    public int velocidadeMovimento;
    public float cdwAtkSpeed;
    public float cdwAtkPulo; 
    public float Hp;
    public float TotalHp { get; set; }
    public float Dmg;
    public float impulsoPulo;
    public float velocidadeNoAr;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        TotalHp = Hp;
	}
	
}
