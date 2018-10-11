using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParedeCollider : MonoBehaviour {

    public bool estaNaParede = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        estaNaParede = true;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        estaNaParede = true;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        estaNaParede = false;
    }

    public bool GetEstaNaParede()
    {
        return this.estaNaParede;
    }
}
