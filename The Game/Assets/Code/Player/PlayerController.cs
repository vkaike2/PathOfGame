using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerService PlayerService { get; set; }

    void Start()
    {
        PlayerService = gameObject.GetComponent<PlayerService>();
    }

    void Update()
    {
        PlayerService.MudarDirecao();
    }

    void FixedUpdate()
    {
        PlayerService.Andar();
        PlayerService.Pular();
        PlayerService.Atacar();
        PlayerService.AtualizaCdw();
    }


}
