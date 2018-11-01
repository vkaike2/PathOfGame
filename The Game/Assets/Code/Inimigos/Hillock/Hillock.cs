using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hillock : MonoBehaviour {

    public Rigidbody2D rb { get; set; }
    public int velHorizontal;
    public float cdwAtkSpeed;
    public float Hp;
    public float Dmg;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
}
