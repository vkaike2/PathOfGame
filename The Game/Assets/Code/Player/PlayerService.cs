using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Utils;

public class PlayerService : MonoBehaviour
{

    private Player player { get; set; }
    private PlayerPuloCollider playerPuloCollider { get; set; }
    private PlayerParedeCollider playerParedeCollider { get; set; }
    private float axisH;
    public GameObject Projetil;
    public GameObject RangeAtack; 
    private float cdwAtk = 0;

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
            player.rb.AddForce(vetHorizontal * (player.velHorizontal * 4));
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

}
