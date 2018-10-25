using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHillockCollider : MonoBehaviour {

    public GameObject Hillock;
    public GameObject ParedeHillock;
    public GameObject MainCamera;
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        FecharParede();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
    }
    void OnTriggerExit2D(Collider2D coll)
    {
    }

    private void FecharParede()
    {
        ParedeHillock.SetActive(true);
        MainCamera.GetComponent<MainCameraController>().AtivarCutscene("Hillock");
        gameObject.SetActive(false);
    }

}
