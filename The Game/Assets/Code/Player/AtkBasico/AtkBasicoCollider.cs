using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasicoCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        IgnorarPlayer(coll);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
    }
    void OnTriggerExit2D(Collider2D coll)
    {
    }

    void IgnorarPlayer(Collider2D coll)
    {
        if(coll.gameObject.tag != "Player")
            Destroy(gameObject);

        if(coll.gameObject.tag == "Enemies")
        {
            coll.gameObject.GetComponent<ZombieService>().ReceberDano(1);
        }

    }
}
