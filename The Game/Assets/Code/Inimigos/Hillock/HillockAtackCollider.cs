using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockAtackCollider : MonoBehaviour
{

    private GameObject player;
    public Inimigo HillockComum { get; set; }
    private float _cdwAtaq;
    private bool podeAtacar;

    void Start()
    {
        HillockComum = gameObject.GetComponentInParent<Inimigo>();
        player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
        _cdwAtaq = 0;
        podeAtacar = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals(TagsUtils.PLAYER))
            podeAtacar = true;
    }
    
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals(TagsUtils.PLAYER))
            podeAtacar = true;
        else
            podeAtacar = false;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals(TagsUtils.PLAYER))
            podeAtacar = false;
    }

    public void EfetuarAtaque()
    {
        if (gameObject.activeSelf)
        {
            _cdwAtaq += Time.deltaTime;
            if (_cdwAtaq >= HillockComum.cdwAtkSpeed)
            {
                if (podeAtacar)
                    player.GetComponent<PlayerService>().ReceberDano(HillockComum.dmg);

                _cdwAtaq = 0;
                gameObject.SetActive(false);
                gameObject.GetComponentInParent<HillockService>().estaAtacando = false;
            }
        }
        else
            _cdwAtaq = 0;
    }
}