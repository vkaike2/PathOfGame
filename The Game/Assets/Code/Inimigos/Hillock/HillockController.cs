using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillockController : MonoBehaviour {

    public HillockService hillockService { get; set; }

    void Start () {
        hillockService = gameObject.GetComponent<HillockService>();
	}
	
	void Update () {
        hillockService.MudarDirecao();
	}

    void FixedUpdate()
    {
        hillockService.Movimentar();
        hillockService.Atacar();
    }
}
