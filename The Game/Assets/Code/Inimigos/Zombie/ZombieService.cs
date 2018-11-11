

using UnityEngine;

public class ZombieService : MonoBehaviour
{
    private float cdwAndar;
    private float cdwAtkSpeed;
    private bool estaAndando;
    private int direcao;
    private Zombie Zombie { get; set; }
    public Transform inicioVisao, fimVisao, visaoChao;
    private GameObject PlayerGameObject { get; set; }
    private int velMovimentoArmazenada = 0;
    public ZombieAtackCollider ZombieAtackCollider { get; set; }

    void Start()
    {
        cdwAndar = 0;
        cdwAtkSpeed = 0;
        direcao = 0;
        estaAndando = false;
        this.Zombie = gameObject.GetComponent<Zombie>();
        this.PlayerGameObject = GameObject.FindWithTag("Player");
        this.ZombieAtackCollider = gameObject.GetComponentInChildren<ZombieAtackCollider>();
    }

    public void Andar()
    {
        Debug.DrawLine(inicioVisao.position, fimVisao.position, Color.red);
        Debug.DrawLine(inicioVisao.position, visaoChao.position, Color.green);
        bool estaVendoPlayer = Physics2D.Linecast(inicioVisao.position, fimVisao.position, 1 << LayerMask.NameToLayer("Player"));

        if (estaVendoPlayer)
            PerseguirPlayer();
        else
            IdleAndar();
    }

    public void Atacar()
    {
        bool deveAtacar = ZombieAtackCollider.DeveAtacar();
        if (deveAtacar)
        {
            if (Zombie.velocidadeMovimento != 0)
                velMovimentoArmazenada = Zombie.velocidadeMovimento;

            Zombie.velocidadeMovimento = 0;
            cdwAtkSpeed += Time.deltaTime;


            if (cdwAtkSpeed >= Zombie.cdwAtkSpeed)
            {
                ZombieAtackCollider.EfetuarAtaque();
                cdwAtkSpeed = 0;
            }
        }
        else
        {
            if (velMovimentoArmazenada != 0)
                Zombie.velocidadeMovimento = velMovimentoArmazenada;

            cdwAtkSpeed = 0;
        }
    }

    public void MudarDirecao()
    {
        if (direcao == 1)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void ReceberDano(float dmg)
    {
        float lifeRestante = Zombie.Hp - dmg;

        if (lifeRestante <= 0)
            Destroy(gameObject);
        else
            Zombie.Hp = lifeRestante;
    }

    private void IdleAndar()
    {
        cdwAndar += Time.deltaTime;
        bool naoVaiCair = Physics2D.Linecast(inicioVisao.position, visaoChao.position, 1 << LayerMask.NameToLayer("Parede"));
        if (cdwAndar >= Zombie.cdwAndar[0] &&
            cdwAndar <= (Zombie.cdwAndar[0] + Zombie.cdwAndar[1]))
        {
            if (!estaAndando)
            {
                direcao = Random.Range(-1, 2);
                estaAndando = true;
            }

            if (naoVaiCair)
            {
                Vector2 velHorizontal = new Vector2(direcao * Zombie.velocidadeMovimento, Zombie.rb.velocity.y);
                Zombie.rb.velocity = velHorizontal;
            }
        }

        if (cdwAndar >= (Zombie.cdwAndar[0] + Zombie.cdwAndar[1]))
        {
            cdwAndar = 0;
            estaAndando = false;
        }
    }

    private void PerseguirPlayer()
    {
        float playerX = PlayerGameObject.transform.position.x;
        float ZombieX = gameObject.transform.position.x;
        if (playerX > ZombieX)
            direcao = 1;
        else
            direcao = -1;

        Vector2 velHorizontal = new Vector2(direcao * Zombie.velocidadeMovimento * 1.5f, Zombie.rb.velocity.y);
        Zombie.rb.velocity = velHorizontal;
    }
}
