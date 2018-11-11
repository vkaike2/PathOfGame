
using Assets.Code.Utils;
using UnityEngine;

public class ZombieAtackCollider : MonoBehaviour {

    public bool estaAtacando = false;
    public bool EncostandoPlayer { get; set; }
    public GameObject dmgCollider;

    void Start () {
        dmgCollider.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == TagsUtils.PLAYER)
            estaAtacando = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == TagsUtils.PLAYER)
            estaAtacando = false;
    }

    public bool DeveAtacar()
    {
        return estaAtacando && !dmgCollider.activeSelf;
    }

    public void EfetuarAtaque()
    {
        dmgCollider.SetActive(true);
    }

}
