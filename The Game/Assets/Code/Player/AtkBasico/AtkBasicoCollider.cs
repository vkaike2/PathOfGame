using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasicoCollider : MonoBehaviour {

    public AtkBasico AtkBasico { get; set; }

    private void Start()
    {
        AtkBasico = gameObject.GetComponent<AtkBasico>();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        IgnorarPlayer(coll);
    }

    void IgnorarPlayer(Collider2D coll)
    {
        if(coll.gameObject.layer != LayersUtils.PLAYER 
            && coll.gameObject.layer != LayersUtils.IGNORE_RAYCAST
            && coll.gameObject.tag != TagsUtils.UNTAGGED)
            Destroy(gameObject);

        if(coll.gameObject.tag == TagsUtils.ENEMIES)
            coll.gameObject.GetComponent<InimigoComum>().ReceberDano(AtkBasico.Damage);
    }
}
