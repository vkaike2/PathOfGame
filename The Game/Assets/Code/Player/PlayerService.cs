using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Utils;
using UnityEngine.SceneManagement;
using System;

public class PlayerService : MonoBehaviour
{
    private Player Player { get; set; }
    private PlayerPuloCollider PlayerPuloCollider { get; set; }
    private PlayerParedeCollider PlayerParedeCollider { get; set; }
    private float axisH;
    public GameObject Projetil;
    public GameObject RangeAtack; 
    private float cdwDmg = 0;
    private float cdwAtk = 0;
    private int velMovimentoAramzaenada = 0;
    private int impPuloArmazenado = 0;

    private Color corOriginal;

    void Start()
    {
        this.Player = gameObject.GetComponent<Player>();
        this.PlayerPuloCollider = gameObject.GetComponentInChildren<PlayerPuloCollider>();
        this.PlayerParedeCollider = gameObject.GetComponentInChildren<PlayerParedeCollider>();
        corOriginal = gameObject.GetComponent<SpriteRenderer>().color;
    }

    public void Andar()
    {
        axisH = Input.GetAxisRaw(AxisUtils.AXIS_HORIZONTAL);

        if (axisH != 0 && !PlayerPuloCollider.GetEstaPulando() && !PlayerParedeCollider.GetEstaNaParede()
            || axisH != 0 && !PlayerPuloCollider.GetEstaPulando() && PlayerParedeCollider.GetEstaNaParede())
        {
            Vector2 vetHorizontal = new Vector2(axisH * Player.velocidadeMoviemnto, Player.rb.velocity.y);
            Player.rb.velocity = vetHorizontal;
        }
        else if (axisH != 0 && PlayerPuloCollider.GetEstaPulando())
        {
            Vector2 vetHorizontal = new Vector2(axisH, 0);
            Player.rb.AddForce(vetHorizontal * (Player.velocidadeMoviemnto * 2));
        }
    }

    public void Pular()
    {
        float axisV = Input.GetAxisRaw(AxisUtils.AXIS_VERTICAL);

        if (axisV != 0 && !PlayerPuloCollider.GetEstaPulando())
        {
            Vector2 vetVertical = new Vector2(0, axisV);
            Player.rb.AddForce(vetVertical * Player.impulsoPulo);
        }
    }

    public void Atacar()
    {
        float fire = Input.GetAxisRaw(AxisUtils.AXIS_FIRE1);

        if (fire != 0 && cdwAtk >= Player.atkSpeed)
        {
            Instantiate(Projetil, RangeAtack.transform.position, gameObject.transform.rotation);
            cdwAtk = 0;
        }
    }

    public void MudarDirecao()
    {
        if(axisH > 0 && gameObject.transform.eulerAngles.y == 180)
            gameObject.transform.eulerAngles = new Vector3(0,0,0);
        else if (axisH < 0 && gameObject.transform.eulerAngles.y == 0)
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void AtualizaCdw()
    {
        cdwAtk += Time.deltaTime;
        cdwDmg += Time.deltaTime;

        if (cdwDmg < Player.cdwDmage)
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        else
            gameObject.GetComponent<SpriteRenderer>().color = corOriginal;
    }

    internal void PararMovimentos(bool pararMovimentos)
    {
        if(pararMovimentos)
        {
            if(velMovimentoAramzaenada == 0 && impPuloArmazenado == 0)
            {
                velMovimentoAramzaenada = Player.velocidadeMoviemnto;
                impPuloArmazenado = Player.impulsoPulo;
            }
            Player.velocidadeMoviemnto = 0;
            Player.impulsoPulo = 0;
        }
        else
        {
            Player.velocidadeMoviemnto = velMovimentoAramzaenada;
            Player.impulsoPulo = impPuloArmazenado;
        }
    }

    public void ReceberDano(float dmg)
    {
        if(cdwDmg >= Player.cdwDmage)
        {
            float lifeRestante = Player.Hp - dmg;
            if (lifeRestante <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                Player.Hp -= dmg;
            }
            cdwDmg = 0;
        }
    }
}
