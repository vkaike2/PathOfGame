using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasico : MonoBehaviour
{
    public GameObject Player { get; set; }
    public float Damage { get; set; }
    public int velHorizontal;
    public int RangeSec;
    public Rigidbody2D rb { get; set; }

    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
        this.rb = gameObject.GetComponent<Rigidbody2D>();
        Damage = Player.GetComponent<Player>().dmg;
    }
}
