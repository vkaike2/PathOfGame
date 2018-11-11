using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Rigidbody2D rb { get; set; }
    public int velocidadeMovimento;
    public List<int> cdwAndar;
    public int cdwAtkSpeed;
    public float Hp;
    public float Dmg;
    public float TotalHp { get; set; }

    void Start()
    {
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.TotalHp = Hp;
    }
}
