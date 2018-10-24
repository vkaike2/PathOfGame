
using UnityEngine;

public class ZombieAtackCollider : MonoBehaviour {

    public ZombieService zombieService { get; set; }
    private bool atacar = false;
    public GameObject dmgCollider;

    void Start () {
        zombieService = gameObject.GetComponentInParent<ZombieService>();
        dmgCollider.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (atacar && !dmgCollider.activeSelf)
        {
            if (zombieService.Atacar())
            {
                dmgCollider.SetActive(true);
            }
        }
        else
        {
            zombieService.ResetarCdwAtaque();
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            atacar = true;
        }

    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            atacar = false;
        }
    }


}
