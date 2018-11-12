using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDmgCollider : MonoBehaviour {

    private Inimigo ZombieComum { get; set; }
    private GameObject Player { get; set; }

    void Start()
    {
        ZombieComum = gameObject.GetComponentInParent<Inimigo>();
        Player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == TagsUtils.PLAYER)
        {
            Player.GetComponent<PlayerService>().ReceberDano(ZombieComum.dmg);
            gameObject.SetActive(false);
        }
    }
}
