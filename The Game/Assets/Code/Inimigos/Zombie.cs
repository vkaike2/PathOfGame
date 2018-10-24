using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int velHorizontal;
    public Rigidbody2D rb { get; set; }
    public List<int> cdwAndar { get; set; }
    public int cdwAtkSpeed { get; set; }
    public float Hp { get; set; }
    public float Dmg { get; set; }

    void Start()
    {
        //this.velHorizontal = 1;
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        this.cdwAndar = new List<int>();
        this.Hp = 1;
        // Ira esperar 2 segunso para comecar a andar
        this.cdwAndar.Add(2);
        // Ira andar durante 1 segundo
        this.cdwAndar.Add(1);
        this.cdwAtkSpeed = 2;
        this.Dmg = 1;
    }
}
