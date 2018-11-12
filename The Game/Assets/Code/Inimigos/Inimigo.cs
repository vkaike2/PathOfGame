using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour {

    public Rigidbody2D Rb { get; set; }
    public int velocidadeMovimento;
    public float cdwAtkSpeed;
    public float hp;
    public float dmg;
    public float reducaoDano;
    public float TotalHp { get; set; }

    void Start () {
        this.TotalHp = hp;
        this.Rb = gameObject.GetComponent<Rigidbody2D>();
	}
}
