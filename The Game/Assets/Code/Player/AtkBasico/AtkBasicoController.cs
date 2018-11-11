using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasicoController : MonoBehaviour
{

    private AtkBasicoService atkBasicoService;

    void Awake()
    {
    }

    void Start()
    {
        atkBasicoService = gameObject.GetComponent<AtkBasicoService>();
        atkBasicoService.DefineDirecao();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        atkBasicoService.Atacar();
        atkBasicoService.AutoDestruir();
    }
}
