using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour {

    float cdwAndar = 0;
    float cdwTimer;
    Rigidbody2D rb;
    bool estaAndando = false;
    int direcao = 0;

    float velocidade = 36;

    void Awake()
    { 
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
    
    void FixedUpdate()
    {
        cdwAndar += Time.deltaTime;

        if(cdwAndar >= 2 && cdwAndar <= 3)
        {
            //int direcao = 0;
            if (!estaAndando)
            {
                direcao = Random.Range(-1, 2);
                estaAndando = true;
            }

            rb.AddForce(new Vector2(velocidade*direcao,0));
            Debug.Log(velocidade * direcao);
        }

        if(cdwAndar >= 3)
        {
            cdwAndar = 0;
            estaAndando = false;
        }

        //Debug.Log(cdwAndar);
    }
}
