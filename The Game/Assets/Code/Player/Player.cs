using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public int velHorizontal { get; set; }
    public int velVertical { get; set; }
    public Rigidbody2D rb { get; set; }


    public Player(GameObject gameObj)
    {
        this.velHorizontal = 5;
        this.velVertical = 1000;
        this.rb = gameObj.GetComponent<Rigidbody2D>();
    }




}
