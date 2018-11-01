using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockService : MonoBehaviour {

    public bool podeAndar { get; set; }
    public bool podeAtacar { get; set; }
    public Hillock Hillock { get; set; }
    public GameObject player;
    private int direcao;
    public GameObject atackCollider;
    float cdwAtaque;

    void Start () {
        podeAndar = false;
        podeAtacar = false;
        Hillock = gameObject.GetComponent<Hillock>();
        atackCollider.SetActive(false);
        cdwAtaque = 0;
	}
	

    internal void StartCutscene()
    {
        //throw new NotImplementedException();
    }

    internal void PararCutscene()
    {
        podeAndar = true;
    }

    public void Movimentar()
    {
        if (podeAndar)
        {
            direcao = 0;
            if (player.transform.position.x > gameObject.transform.position.x)
                direcao = 1;
            else
                direcao = -1;

            Vector2 velHorizontal = new Vector2(direcao * Hillock.velHorizontal , Hillock.rb.velocity.y);
            Hillock.rb.velocity = velHorizontal;
        }
    }

    public void MudarDirecao()
    {
        if (direcao == 1)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void Atacar()
    {
        if (podeAtacar)
        {
            if(!atackCollider.activeSelf)
                atackCollider.SetActive(true);


            //cdwAtaque += Time.deltaTime;
            //if(cdwAtaque >= Hillock.cdwAtkSpeed)
            //{
            //    atackCollider.SetActive(true);
            //    cdwAtaque = 0;
            //}

        }
    }

    public void ReceberDano(float dmg)
    {
        float lifeRestante = Hillock.Hp - dmg;

        if (lifeRestante <= 0)
            Destroy(gameObject);
        else
            Hillock.Hp = lifeRestante;
    }
}
