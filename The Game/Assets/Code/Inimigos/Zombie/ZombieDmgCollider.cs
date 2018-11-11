using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDmgCollider : MonoBehaviour {

    private Zombie Zombie { get; set; }
    private GameObject Player { get; set; }

    void Start()
    {
        Zombie = gameObject.GetComponentInParent<Zombie>();
        Player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == TagsUtils.PLAYER)
        {
            Player.GetComponent<PlayerService>().ReceberDano(Zombie.Dmg);
            gameObject.SetActive(false);
        }
    }
}
