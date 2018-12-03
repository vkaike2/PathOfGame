using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    #region Atributos
    public PlayerService PlayerService { get; set; }
    #endregion

    #region Start
    void Start ()
    {
        PlayerService = gameObject.GetComponent<PlayerService>();
    }
    #endregion

    #region Loop
    void Update ()
    {
        PlayerService.MudarDirecao();
    }
    void FixedUpdate()
    {
        PlayerService.Andar();
        PlayerService.Pular();
    }
    #endregion
}
