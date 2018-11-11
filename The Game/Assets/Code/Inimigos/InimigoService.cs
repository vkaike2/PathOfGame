using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoService : MonoBehaviour
{

    public float reducaoDano;
    public Zombie zombie;
    public Hillock hillock;
    public float Hp { get; set; }
    public float Dmg { get; set; }

    void Start()
    {
        if (zombie != null)
        {
            Hp = zombie.Hp;
            Dmg = zombie.Dmg;
        }
        else if (hillock != null)
        {
            Hp = hillock.Hp;
            Dmg = hillock.Dmg;
        }
    }

    public void ReceberDano(float dmg)
    {
        if (zombie != null)
            gameObject.GetComponent<ZombieService>().ReceberDano(dmg);
        else
            gameObject.GetComponent<HillockService>().ReceberDano(dmg);
        //float lifeRestante = Hp - dmg;
        //if (lifeRestante <= 0)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    Hp -= dmg;
        //}
    }
}
