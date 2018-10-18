﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieService : MonoBehaviour
{
    private float cdwAndar = 0;
    private bool estaAndando = false;
    private int direcao = 0;
    private Zombie zombie { get; set; }
    public Transform inicioVisao, fimVisao;
    private GameObject PlayerGameObject { get; set; }

    void Start()
    {
        this.zombie = gameObject.GetComponent<Zombie>();
        this.PlayerGameObject = GameObject.FindWithTag("Player");
    }

    public void Andar()
    {
        Debug.DrawLine(inicioVisao.position, fimVisao.position, Color.red);
        bool estaVendoPlayer = Physics2D.Linecast(inicioVisao.position, fimVisao.position, 1 << LayerMask.NameToLayer("Player"));

        if (estaVendoPlayer)
        {
            PerseguirPlayer();
        }
        else
        {
            IdleAndar();
        }
    }

    private void PerseguirPlayer()
    {
        float playerX = PlayerGameObject.transform.position.x;
        float ZombieX = gameObject.transform.position.x;
        if (playerX > ZombieX)
        {
            direcao = 1;
        }
        else
        {
            direcao = -1;
        }
        Vector2 velHorizontal = new Vector2(direcao * zombie.velHorizontal * 1.5f, zombie.rb.velocity.y);
        zombie.rb.velocity = velHorizontal;
    }

    private void IdleAndar()
    {
        cdwAndar += Time.deltaTime;

        if (cdwAndar >= zombie.cdwAndar[0] &&
            cdwAndar <= (zombie.cdwAndar[0] + zombie.cdwAndar[1]))
        {
            if (!estaAndando)
            {
                direcao = Random.Range(-1, 2);
                estaAndando = true;
            }
            Vector2 velHorizontal = new Vector2(direcao * zombie.velHorizontal, zombie.rb.velocity.y);
            zombie.rb.velocity = velHorizontal;
        }

        if (cdwAndar >= (zombie.cdwAndar[0] + zombie.cdwAndar[1]))
        {
            cdwAndar = 0;
            estaAndando = false;
        }
    }

    public void MudarDirecao()
    {
        if (direcao == 1)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void ReceberDano(float dmg)
    {
        float lifeRestante = zombie.Hp - dmg;

        if (lifeRestante <= 0)
        {
            Destroy(gameObject);
        }
    }
}
