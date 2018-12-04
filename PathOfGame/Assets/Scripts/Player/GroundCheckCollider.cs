using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckCollider : MonoBehaviour {

    #region Atributos
    public PlayerService PlayerService { get; set; }
    #endregion

    #region Start
    void Start () {
        PlayerService = gameObject.GetComponentInParent<PlayerService>();
	}
    #endregion

    #region Colliders
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Teste")
        {
            GameObject.Find("Main Camera").GetComponent<MainCameraController>().enabled = false;
        }

        PlayerService.EstaNoChao(true, coll);
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        PlayerService.EstaNoChao(true, coll);
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        PlayerService.EstaNoChao(false, coll);

        if (coll.gameObject.name == "Teste")
        {
            GameObject.Find("Main Camera").GetComponent<MainCameraController>().enabled = true;
        }
    }
    #endregion
}
