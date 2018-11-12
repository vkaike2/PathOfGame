

using UnityEngine;

public class ZombieService : MonoBehaviour
{
    private float _cdwAndar;
    private float _cdwAtkSpeed;
    private bool estaAndando;
    private int direcao;
    private Zombie Zombie { get; set; }
    public Inimigo ZombieComum { get; set; }
    public Transform inicioVisao, fimVisao, visaoChao;
    private GameObject PlayerGameObject { get; set; }
    private int velMovimentoArmazenada = 0;
    public ZombieAtackCollider ZombieAtackCollider { get; set; }

    void Start()
    {
        _cdwAndar = 0;
        _cdwAtkSpeed = 0;
        direcao = 0;
        estaAndando = false;
        this.ZombieComum = gameObject.GetComponent<Inimigo>();
        this.Zombie = gameObject.GetComponent<Zombie>();
        this.PlayerGameObject = GameObject.FindWithTag("Player");
        this.ZombieAtackCollider = gameObject.GetComponentInChildren<ZombieAtackCollider>();
    }

    public void ControlaMovimento()
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
            if (ZombieComum.velocidadeMovimento != 0)
                velMovimentoArmazenada = ZombieComum.velocidadeMovimento;

            ZombieComum.velocidadeMovimento = 0;
            _cdwAtkSpeed += Time.deltaTime;


            if (_cdwAtkSpeed >= ZombieComum.cdwAtkSpeed)
            {
                ZombieAtackCollider.EfetuarAtaque();
                _cdwAtkSpeed = 0;
            }
        }
        else
        {
            if (velMovimentoArmazenada != 0)
                ZombieComum.velocidadeMovimento = velMovimentoArmazenada;

            _cdwAtkSpeed = 0;
        }
    }

    public void MudarDirecao()
    {
        if (direcao == 1)
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        else
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    /*
     * Anda Randomicamente durante o tempo descrito em "Zombie.andaPor" a cada "Zombie.cdwAndar"
     */
    private void IdleAndar()
    {
        _cdwAndar += Time.deltaTime;
        bool naoVaiCair = Physics2D.Linecast(inicioVisao.position, visaoChao.position, 1 << LayerMask.NameToLayer("Parede"));

        if (_cdwAndar >= Zombie.cdwAndar &&
            _cdwAndar <= (Zombie.andaPor + Zombie.cdwAndar))
        {
            if (!estaAndando)
            {
                direcao = Random.Range(-1, 2);
                estaAndando = true;
            }

            if (naoVaiCair)
            {
                Vector2 velHorizontal = new Vector2(direcao * ZombieComum.velocidadeMovimento, ZombieComum.Rb.velocity.y);
                ZombieComum.Rb.velocity = velHorizontal;
            }
        }

        if (_cdwAndar >= (Zombie.andaPor + Zombie.cdwAndar))
        {
            _cdwAndar = 0;
            estaAndando = false;
        }
    }

    /*
     * Quando o player esta no campo de vizão do Zombie ele persegue ele 
     */
    private void PerseguirPlayer()
    {
        float playerX = PlayerGameObject.transform.position.x;
        float ZombieX = gameObject.transform.position.x;
        if (playerX > ZombieX)
            direcao = 1;
        else
            direcao = -1;

        Vector2 velHorizontal = new Vector2(direcao * ZombieComum.velocidadeMovimento * 1.3f, ZombieComum.Rb.velocity.y);
        ZombieComum.Rb.velocity = velHorizontal;
    }
}
