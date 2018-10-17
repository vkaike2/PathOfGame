using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasicoService : MonoBehaviour
{
    private AtkBasico AtkBasico { get; set; }
    private int direcao { get; set; }
    private float cdwRange = 0;
    public Transform InicioColisor;
    public Transform FimColisor;

    void Start()
    {
        this.AtkBasico = gameObject.GetComponent<AtkBasico>();
    }

    public void DefineDirecao()
    {
        if (gameObject.transform.eulerAngles.y == 0)
            direcao = 1;
        else
            direcao = -1;
    }

    public void Atacar()
    {
        AtkBasico.rb.velocity = new Vector2(AtkBasico.velHorizontal * direcao, 0);
    }

    public void Excluir()
    {
        cdwRange += Time.deltaTime;

        Transform fimVisao = gameObject.transform;

        Debug.DrawLine(InicioColisor.position, FimColisor.position, Color.red);
        RaycastHit2D colidiu = Physics2D.Raycast(InicioColisor.position, FimColisor.position, 0.5f);
        
        if (cdwRange > AtkBasico.RangeSec
            || colidiu.collider !=null && colidiu.collider.IsTouchingLayers() 
            )
        {
            Debug.Log(colidiu.collider);
            Destroy(gameObject);
        }
    }
}
