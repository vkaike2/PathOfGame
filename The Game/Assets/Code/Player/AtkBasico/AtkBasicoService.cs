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

    public void AutoDestruir()
    {
        cdwRange += Time.deltaTime;
        if (cdwRange > AtkBasico.RangeSec)
            Destroy(gameObject);
    }
}
