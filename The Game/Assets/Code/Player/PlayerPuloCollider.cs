using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuloCollider : MonoBehaviour
{

    public bool estaPulando = false;


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer != LayersUtils.ENEMIES)
            estaPulando = false;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.layer != LayersUtils.ENEMIES)
            estaPulando = false;
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer != LayersUtils.ENEMIES)
            estaPulando = true;
    }

    public bool GetEstaPulando()
    {
        return this.estaPulando;
    }
}
