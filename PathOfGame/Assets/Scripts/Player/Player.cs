using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region Atributos
    public Rigidbody2D RigidBody { get; set; }
    public Animator Animator { get; set; }
    public int velocidadeMoviemnto;
    public int impulsoPulo;
    public float atkSpeed;
    public float Hp;
    public float safeCdw;
    public float dmg;
    public bool EstaNoChao { get; set; }
    #endregion

    #region Start
    void Start ()
    {
        RigidBody = gameObject.GetComponent<Rigidbody2D>();
        Animator = gameObject.GetComponent<Animator>();
    }
    #endregion


    #region Animator
    public bool AnimGetAndando()
    {
        return Animator.GetBool("Andando");
    }
    public void AnimSetAndando(bool valor)
    {
        Animator.SetBool("Andando", valor);
    }
    public bool AnimGetEstaNoChao()
    {
        return Animator.GetBool("EstaNoChao");
    }
    public void AnimSetEstaNoChao(bool valor)
    {
        Animator.SetBool("EstaNoChao", valor);
    }
    public bool AnimGetPSubindo()
    {
        return Animator.GetBool("P_Subindo");
    }
    public void AnimSetPSubindo(bool valor)
    {
        Animator.SetBool("P_Subindo", valor);
    }
    #endregion
}
