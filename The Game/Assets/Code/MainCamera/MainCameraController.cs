using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;

    public GameObject Hillock;
    public GameObject Player;
    public bool Cutscene { get; set; }
    public bool HillockCs { get; set; }

    private float cdwCs = 0;
    private Camera camera;

    void Start()
    {
        offset = transform.position - player.transform.position;
        Cutscene = false;
        HillockCs = false;
        camera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (HillockCs)
            HillockCutscene();
    }

    void LateUpdate()
    {
        if (!Cutscene)
        {
            transform.position = player.transform.position + offset;
        }
    }

    public void AtivarCutscene(string cutscene)
    {
        if (cutscene.Equals("Hillock"))
        {
            Cutscene = true;
            HillockCs = true;
        }
    }
    private int contadorAnimacao = 0;
    private void HillockCutscene()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        Player.GetComponent<PlayerService>().PararMovimentos(true);
        if (x <= 138.9f && cdwCs == 0)
        {
            transform.position = new Vector3(
                x + 0.2f,
                y + 0.08f,
                transform.position.z);
            contadorAnimacao++;
            camera.orthographicSize += 0.101f;
        }
        else
        {
            cdwCs += Time.deltaTime;

            if (cdwCs >= 3)
            {
                Hillock.GetComponent<HillockService>().StartCutscene();
                if (x >= 124.5f)
                {
                    transform.position = new Vector3(
                        x - 0.2f,
                        y - 0.08f,
                        transform.position.z);
                    camera.orthographicSize -= 0.101f;
                }
                else
                {
                    cdwCs = 0;
                    contadorAnimacao = 0;
                    Player.GetComponent<PlayerService>().PararMovimentos(false);
                    HillockCs = false;
                    Cutscene = false;
                }
            }

        }
    }
}

