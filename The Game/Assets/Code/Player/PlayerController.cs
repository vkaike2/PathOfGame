using Assets.Code.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerService playerService;
    //public GameObject projetil;
    //public GameObject rangeAtack;

    void Awake()
    {
        //playerService = new PlayerService(gameObject, projetil, rangeAtack);
    }

    void Start()
    {
        playerService = gameObject.GetComponent<PlayerService>();
    }

    void Update()
    {
        playerService.MudarDirecao();
    }

    void FixedUpdate()
    {
        playerService.Andar();
        playerService.Pular();
        playerService.atacar();
    }


}
