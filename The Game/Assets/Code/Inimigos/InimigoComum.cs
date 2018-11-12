using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoComum : MonoBehaviour {

    public Inimigo Inimigo { get; set; }

    private void Start()
    {
        Inimigo = gameObject.GetComponent<Inimigo>();
    }

    public void ReceberDano(float dmg)
    {
        Debug.Log("Hit: " + gameObject);

        if(Inimigo.reducaoDano != 0)
        {
            dmg *= Inimigo.reducaoDano;
        }

        float lifeRestante = Inimigo.hp - dmg;
        if(lifeRestante <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Inimigo.hp = lifeRestante;
        }
    }

}
