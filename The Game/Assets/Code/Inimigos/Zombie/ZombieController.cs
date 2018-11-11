using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private ZombieService zombieService;

    void Awake()
    {
    }

    void Start()
    {
        zombieService = gameObject.GetComponent<ZombieService>();
    }

    void Update()
    {
        zombieService.MudarDirecao();
    }

    void FixedUpdate()
    {
        zombieService.Andar();
        zombieService.Atacar();
    }
}
