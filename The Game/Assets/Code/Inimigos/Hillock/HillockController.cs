using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockController : MonoBehaviour {

    public HillockService HillockService { get; set; }

    void Start () {
        HillockService = gameObject.GetComponent<HillockService>();
	}
	
	void Update () {
        HillockService.MudarDirecao();
	}

    void FixedUpdate()
    {
        HillockService.Movimentar();
        HillockService.Atacar();
        HillockService.MovimentaNoAr();
    }
}
