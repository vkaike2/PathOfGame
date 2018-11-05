using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockAtackCollider : MonoBehaviour
{

    private GameObject player;
    public Hillock Hillock { get; set; }
    private float cdwAtaq;
    private bool podeAtacar;

    void Start()
    {
        Hillock = gameObject.GetComponentInParent<Hillock>();
        player = GameObject.FindGameObjectWithTag("Player");
        cdwAtaq = 0;
        podeAtacar = false;
    }

    void FixedUpdate()
    {
        if (gameObject.activeSelf)
        {
            cdwAtaq += Time.deltaTime;
            if (cdwAtaq >= Hillock.cdwAtkSpeed)
            {
                if (podeAtacar)
                    player.GetComponent<PlayerService>().ReceberDano(Hillock.Dmg);

                cdwAtaq = 0;
                gameObject.SetActive(false);
                gameObject.GetComponent<HillockService>().estaAtacando = false;
            }
        }
        else
            cdwAtaq = 0;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
            podeAtacar = true;
    }
    
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
            podeAtacar = true;
        else
            podeAtacar = false;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
            podeAtacar = false;
    }

}