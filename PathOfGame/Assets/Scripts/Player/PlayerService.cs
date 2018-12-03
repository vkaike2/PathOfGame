using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    #region Atributos
    public Player Player { get; set; }
    public float AxisHorizontal { get; set; }
    public float AxisJump { get; set; }
    #endregion

    #region Start
    void Start()
    {
        Player = gameObject.GetComponent<Player>();
    }
    #endregion

    #region Metodos Publicos
    public void Andar()
    {
        AxisHorizontal = Input.GetAxisRaw(AxisUtils.AXIS_HORIZONTAL);

        if (AxisHorizontal != 0)
            Player.AnimSetAndando(true);
        else
            Player.AnimSetAndando(false);

        Player.RigidBody.velocity = new Vector2(AxisHorizontal * Player.velocidadeMoviemnto, Player.RigidBody.velocity.y);
    }

    public void MudarDirecao()
    {
        if (AxisHorizontal > 0 && gameObject.transform.eulerAngles.y == 180)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else if (AxisHorizontal < 0 && gameObject.transform.eulerAngles.y == 0)
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void EstaNoChao(bool valor, Collider2D coll)
    {
        if (coll.gameObject.layer == LayersUtils.CHAO)
        {
            Player.EstaNoChao = valor;
            Player.AnimSetEstaNoChao(valor);
        }
    }

    public void Pular()
    {
        AxisJump = Input.GetAxisRaw(AxisUtils.AXIS_JUMP);

        if (AxisJump != 0 && Player.EstaNoChao)
        {
            Player.RigidBody.velocity = Vector2.up * Player.impulsoPulo;
        }

        if(Player.RigidBody.velocity.y <= 0)
        {
            Player.AnimSetPSubindo(false);
        }
        else
        {
            Player.AnimSetPSubindo(true);
        }
    }
    #endregion

    #region Metodos Privados
    #endregion
}
