using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Code.Utils;

public class PlayerService : MonoBehaviour {

    public Player player { get; set; }
    public PlayerPuloCollider playerPuloCollider { get; set; }
    public PlayerParedeCollider playerParedeCollider { get; set; }

    public PlayerService(GameObject gameObj)
    {
        this.player = new Player(gameObj);
        this.playerPuloCollider = gameObj.GetComponentInChildren<PlayerPuloCollider>();
        this.playerParedeCollider = gameObj.GetComponentInChildren<PlayerParedeCollider>();
    }

    public void andar()
    {
        float axisH = Input.GetAxisRaw(AxisUtils.AXIS_HORIZONTAL);

        if (axisH != 0 && !playerPuloCollider.GetEstaPulando() && !playerParedeCollider.GetEstaNaParede()
            || axisH != 0 && !playerPuloCollider.GetEstaPulando() && playerParedeCollider.GetEstaNaParede())
        {
            Vector2 vetHorizontal = new Vector2(axisH * player.velHorizontal, player.rb.velocity.y);
            player.rb.velocity = vetHorizontal;
        }else if(axisH != 0 && playerPuloCollider.GetEstaPulando())
        {
            Vector2 vetHorizontal = new Vector2(axisH, 0);
            player.rb.AddForce(vetHorizontal * (player.velHorizontal*4));
        }
    }

    public void pular()
    {
        float axisV = Input.GetAxisRaw(AxisUtils.AXIS_VERTICAL);

        if(axisV != 0 && !playerPuloCollider.GetEstaPulando())
        {
            Vector2 vetVertical = new Vector2(0, axisV);
            player.rb.AddForce(vetVertical * player.velVertical);
        }
    }

}
