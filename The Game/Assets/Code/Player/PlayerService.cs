using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Utils;
using UnityEngine.SceneManagement;
using System;

public class PlayerService : MonoBehaviour
{

    private Player player { get; set; }
    private PlayerPuloCollider playerPuloCollider { get; set; }
    private PlayerParedeCollider playerParedeCollider { get; set; }
    private float axisH;
    public GameObject Projetil;
    public GameObject RangeAtack; 
    private float cdwAtk = 0;

    //Guarda a Velocidade Horizontal do Player Quando ele para o Moviemnto
    private int vHorizontal = 0;
    //Guarda a Velocidade Verical do Player Quando ele para o Moviemnto
    private int vVerical = 0;

    void Start()
    {
        this.player = gameObject.GetComponent<Player>();
        this.playerPuloCollider = gameObject.GetComponentInChildren<PlayerPuloCollider>();
        this.playerParedeCollider = gameObject.GetComponentInChildren<PlayerParedeCollider>();
    }

    public void Andar()
    {
        axisH = Input.GetAxisRaw(AxisUtils.AXIS_HORIZONTAL);

        if (axisH != 0 && !playerPuloCollider.GetEstaPulando() && !playerParedeCollider.GetEstaNaParede()
            || axisH != 0 && !playerPuloCollider.GetEstaPulando() && playerParedeCollider.GetEstaNaParede())
        {
            Vector2 vetHorizontal = new Vector2(axisH * player.velHorizontal, player.rb.velocity.y);
            player.rb.velocity = vetHorizontal;
        }
        else if (axisH != 0 && playerPuloCollider.GetEstaPulando())
        {
            Vector2 vetHorizontal = new Vector2(axisH, 0);
            player.rb.AddForce(vetHorizontal * (player.velHorizontal * 3));
        }
    }

    public void Pular()
    {
        float axisV = Input.GetAxisRaw(AxisUtils.AXIS_VERTICAL);

        if (axisV != 0 && !playerPuloCollider.GetEstaPulando())
        {
            Vector2 vetVertical = new Vector2(0, axisV);
            player.rb.AddForce(vetVertical * player.velVertical);
        }
    }

    public void atacar()
    {
        float fire = Input.GetAxisRaw(AxisUtils.AXIS_FIRE1);
        cdwAtk += Time.deltaTime;

        if (fire != 0 && cdwAtk >= player.atkSpeed)
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

    public void ReceberDano(float dmg)
    {
        float lifeRestante = player.Hp - dmg;
        Debug.Log("Ai pai Para!");
        if (lifeRestante <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            player.Hp -= dmg;
        }
    }

    internal void PararMovimentos(bool pararMovimentos)
    {
        if(pararMovimentos)
        {
            if(vHorizontal == 0 && vVerical == 0)
            {
                vHorizontal = player.velHorizontal;
                vVerical = player.velVertical;
            }
            player.velHorizontal = 0;
            player.velVertical = 0;
        }
        else
        {
            player.velHorizontal = vHorizontal;
            player.velVertical = vVerical;
        }
        //throw new NotImplementedException();
    }
}
