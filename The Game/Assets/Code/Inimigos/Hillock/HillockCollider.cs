using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            gameObject.GetComponent<HillockService>().podeAndar = false;
            gameObject.GetComponent<HillockService>().podeAtacar = true;
        }

        if (coll.gameObject.tag == "Parede")
            gameObject.GetComponent<HillockService>().estaNoChao = true;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
    }
    void OnTriggerExit2D(Collider2D coll)
    {

        if(coll.gameObject.tag == "Parede")
            gameObject.GetComponent<HillockService>().estaNoChao = false;

        if (coll.gameObject.tag == "Player")
        {
            gameObject.GetComponent<HillockService>().podeAndar = true;
            gameObject.GetComponent<HillockService>().podeAtacar = false;
        }
    }
}
