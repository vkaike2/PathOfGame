using Assets.Code.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{

    public Vector3 Offset { get; set; }
    public GameObject hillock;
    public GameObject player;
    public bool Cutscene { get; set; }
    public bool HillockCs { get; set; }

    private float _cdwCs = 0;
    private int _countAnimacao = 0;
    public Camera Camera { get; set; }

    void Start()
    {
        Offset = transform.position - player.transform.position;
        Cutscene = false;
        HillockCs = false;
        Camera = gameObject.GetComponent<Camera>();
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
            transform.position = player.transform.position + Offset;
        }
    }

    public void AtivarCutscene(string cutscene)
    {
        if (cutscene.Equals(CutscenesUtils.HILLOCK))
        {
            Cutscene = true;
            HillockCs = true;
        }
    }

    private void HillockCutscene()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        player.GetComponent<PlayerService>().PararMovimentos(true);
        if (x <= 138.9f && _cdwCs == 0)
        {
            transform.position = new Vector3(
                x + 0.2f,
                y + 0.08f,
                transform.position.z);
            _countAnimacao++;
            Camera.orthographicSize += 0.101f;
        }
        else
        {
            _cdwCs += Time.deltaTime;

            if (_cdwCs >= 3)
            {
                hillock.GetComponent<HillockService>().StartCutscene();
                if (x >= 124.5f)
                {
                    transform.position = new Vector3(
                        x - 0.2f,
                        y - 0.08f,
                        transform.position.z);
                    Camera.orthographicSize -= 0.101f;
                }
                else
                {
                    _cdwCs = 0;
                    _countAnimacao = 0;
                    player.GetComponent<PlayerService>().PararMovimentos(false);
                    hillock.GetComponent<HillockService>().PararCutscene();
                    HillockCs = false;
                    Cutscene = false;
                }
            }

        }
    }
}

