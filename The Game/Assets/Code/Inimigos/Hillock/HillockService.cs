using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockService : MonoBehaviour {

    public bool podeAndar { get; set; }
    public bool podeAtacar { get; set; }
    public Hillock Hillock { get; set; }
    public GameObject atackCollider;
    public float forcaPulo;
    public float alturaPulo;
    public bool estaNoChao = true;

    public bool estaAtacando;
    private GameObject player;
    private int direcao;
    private bool rage = false;
    private float cdwPulo;

    void Start () {
        podeAndar = false;
        podeAtacar = false;
        estaAtacando = false;
        Hillock = gameObject.GetComponent<Hillock>();
        atackCollider.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        cdwPulo = 0;
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

            Vector2 velHorizontal = new Vector2(direcao * Hillock.velHorizontal, Hillock.rb.velocity.y);
            Hillock.rb.velocity = velHorizontal;

            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Hillock.velHorizontal);
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
        if (!rage)
        {
            AtkMelee();
        }
        else
        {
            cdwPulo += Time.deltaTime;
            if (cdwPulo >= Hillock.cdwAtkPulo)
            {
                if(!estaAtacando)
                    AtkPulo();

                cdwPulo = 0;
            }

            AtkMelee();
        }
    }

    public void ReceberDano(float dmg)
    {
        float lifeRestante = Hillock.Hp - dmg;

        if (lifeRestante <= 0)
            Destroy(gameObject);
        else
        {
            Hillock.Hp = lifeRestante;
            if (lifeRestante <= Hillock.TotalHp * 0.3)
                rage = true;
        }
    }

    public void MovimentaNoAr()
    {
        if (!estaNoChao)
        {
            float playerX = player.transform.position.x;
            float x = gameObject.transform.position.x;
            float diferenca = playerX - x;

            if (diferenca < 0)
                diferenca *= -1;

            Hillock.rb.AddForce(new Vector2(forcaPulo*direcao*diferenca,0));
        }
    }

    private void AtkMelee()
    {
        if (podeAtacar)
            if (!atackCollider.activeSelf)
            {
                atackCollider.SetActive(true);
                estaAtacando = true;
            }
            else
            {
                estaAtacando = false;
            }
    }

    private void AtkPulo()
    {

        float playerX = player.transform.position.x;
        float x = gameObject.transform.position.x;
        float diferenca = playerX - x;

        if (diferenca < 0)
            diferenca *= -1;

        Hillock.rb.velocity = new Vector2(0, alturaPulo);
    }

}
