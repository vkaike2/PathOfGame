using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public int velHorizontal;
    public List<int> cdwAndar;
    public int cdwAtkSpeed;
    public float Hp;
    public float Dmg;

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
