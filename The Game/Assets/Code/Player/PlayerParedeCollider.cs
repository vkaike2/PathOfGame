using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParedeCollider : MonoBehaviour {

    public bool estaNaParede = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        estaNaParede = true;
        if (coll.gameObject.layer == LayersUtils.ENEMIES)
            gameObject.GetComponentInParent<PlayerService>().ReceberDano(1);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        estaNaParede = true;

        
        if (coll.gameObject.layer == LayersUtils.ENEMIES)
            gameObject.GetComponentInParent<PlayerService>().ReceberDano(1);
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
