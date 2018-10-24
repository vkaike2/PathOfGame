using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDmgCollider : MonoBehaviour {

    private Zombie zombie { get; set; }
    public GameObject player;

    void Start()
    {
        zombie = gameObject.GetComponentInParent<Zombie>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.Equals(player))
        {
            coll.gameObject.GetComponent<PlayerService>().ReceberDano(zombie.Dmg);
            gameObject.SetActive(false);
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {

    }
    void OnTriggerExit2D(Collider2D coll)
    {
    }
}
