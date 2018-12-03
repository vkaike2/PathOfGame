using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    #region Atributos
    public Vector3 Offset { get; set; }
    public GameObject player;
    #endregion

    #region Start
    void Start()
    {
        Offset = transform.position - player.transform.position;
    }
    #endregion

    #region Loop
    void LateUpdate()
    {
        Debug.Log(Offset);
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z) + new Vector3(Offset.x,0,Offset.z);
    }
    #endregion
}
