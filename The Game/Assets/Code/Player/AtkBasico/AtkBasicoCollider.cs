using Assets.Code.Utils;
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
        if(coll.gameObject.layer != LayersUtils.PLAYER 
            && coll.gameObject.layer != LayersUtils.IGNORE_RAYCAST
            && coll.gameObject.tag != TagsUtils.UNTAGGED)
            Destroy(gameObject);

        if(coll.gameObject.tag == TagsUtils.ENEMIES)
        {
            coll.gameObject.GetComponent<InimigoService>().ReceberDano(1);
        }
    }
}
