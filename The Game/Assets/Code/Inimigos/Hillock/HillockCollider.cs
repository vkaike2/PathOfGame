using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == TagsUtils.PLAYER)
        {
            gameObject.GetComponent<HillockService>().PodeAndar = false;
            gameObject.GetComponent<HillockService>().PodeAtacar = true;
        }

        if (coll.gameObject.tag == TagsUtils.PLAYER)
            gameObject.GetComponent<HillockService>().estaNoChao = true;
    }
    void OnTriggerExit2D(Collider2D coll)
    {

        if(coll.gameObject.tag == TagsUtils.PAREDE)
            gameObject.GetComponent<HillockService>().estaNoChao = false;

        if (coll.gameObject.tag == TagsUtils.PLAYER)
        {
            gameObject.GetComponent<HillockService>().PodeAndar = true;
            gameObject.GetComponent<HillockService>().PodeAtacar = false;
        }
    }
}
