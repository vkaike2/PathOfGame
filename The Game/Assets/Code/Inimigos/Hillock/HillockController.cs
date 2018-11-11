using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockController : MonoBehaviour {

    public HillockService HillockService { get; set; }
    public HillockAtackCollider HillockAtackCollider { get; set; }

    void Start () {
        HillockService = gameObject.GetComponent<HillockService>();
        HillockAtackCollider = gameObject.GetComponentInChildren<HillockAtackCollider>();
    }
	
	void Update () {
        HillockService.MudarDirecao();
	}

    void FixedUpdate()
    {
        HillockService.Movimentar();
        HillockService.Atacar();
        HillockService.MovimentaNoAr();
        HillockAtackCollider.EfetuarAtaque();
    }
}
