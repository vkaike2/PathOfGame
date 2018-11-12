using Assets.Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockService : MonoBehaviour
{

    public bool PodeAndar { get; set; }
    public bool PodeAtacar { get; set; }
    public Hillock Hillock { get; set; }
    public Inimigo HillockComum { get; set; }
    public GameObject atackCollider;
    public bool estaNoChao = true;

    public bool estaAtacando;
    private GameObject player;
    private int direcao;
    public bool rage = false;
    private float cdwPulo;

    void Start()
    {
        PodeAndar = false;
        PodeAtacar = false;
        estaAtacando = false;
        Hillock = gameObject.GetComponent<Hillock>();
        HillockComum = gameObject.GetComponent<Inimigo>();
        atackCollider.SetActive(false);
        player = GameObject.FindGameObjectWithTag(TagsUtils.PLAYER);
        cdwPulo = 0;
    }

    internal void StartCutscene()
    {
        //throw new NotImplementedException();
    }

    internal void PararCutscene()
    {
        PodeAndar = true;
    }

    public void Movimentar()
    {
        if (PodeAndar)
        {
            direcao = 0;
            if (player.transform.position.x > gameObject.transform.position.x)
                direcao = 1;
            else
                direcao = -1;

            Vector2 velHorizontal = new Vector2(direcao * HillockComum.velocidadeMovimento, HillockComum.Rb.velocity.y);
            HillockComum.Rb.velocity = velHorizontal;
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
                if (!estaAtacando)
                    AtkPulo();

                cdwPulo = 0;
            }

            AtkMelee();
        }
    }

    public void AtualizaRage()
    {
        if (HillockComum.hp <= (HillockComum.TotalHp * 0.3))
            rage = true;
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

            HillockComum.Rb.AddForce(new Vector2(Hillock.velocidadeNoAr * direcao * diferenca, 0));
        }
    }

    private void AtkMelee()
    {
        if (PodeAtacar)
        {
            if (!atackCollider.activeSelf)
            {
                atackCollider.SetActive(true);
                estaAtacando = true;
            }
        }
    }

    private void AtkPulo()
    {

        float playerX = player.transform.position.x;
        float x = gameObject.transform.position.x;
        float diferenca = playerX - x;

        if (diferenca < 0)
            diferenca *= -1;

        HillockComum.Rb.velocity = new Vector2(0, Hillock.impulsoPulo);
    }

}
