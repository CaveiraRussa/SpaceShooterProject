using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float smooth = 5f;
    private Quaternion posicaoInicial;
    private bool giro;
    private bool sentido;
    private Animator animator;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private Transform player;
    public float moveSpeed;
    private Rigidbody2D rb2D;
    public float manoverRate;
    private float nextManover;
    private bool doABarrelRoll;
    private bool flip;
    private bool highlander;
    private int side;
    private int sideSpeed = 10;
    public GameObject explosion;
    [SerializeField] private Collider2D immortal;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // testa se o objeto existe
        if (player == null)
        {
            Debug.Log("Cannot find 'player' script");
        }
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        giro = false;
        sentido = true;
        posicaoInicial = transform.rotation;
        flip = false;
        highlander = true;
        side = 2;
    }
    void FixedUpdate()
    {
        Vector3 direction = player.position - transform.position;

        if (giro == false)
        {
            if ((direction.y < 20f && direction.y > -20f) && (direction.x < 10 && direction.x > -10))
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(shot, shotSpawn.position, transform.rotation);
                    animacaoAtaque();
                    GetComponent<AudioSource>().Play();
                }

            }

        }

        if (direction.y < 0 && sentido == false)
        {
            giro = true;
            sentido = false;
        }
        if (direction.y > 0 && sentido == true)
        {
            giro = true;
            sentido = true;
        }

        if (giro)
        {
            if (doABarrelRoll == false)
            {
                if (sentido)
                {
                    if (transform.rotation.z >=0.9 && transform.rotation.z < 1|| (transform.rotation.z == -1f || transform.rotation.z == 1f))
                    {
                        transform.Rotate(Vector3.back * 0);
                        Vector3 eulerRotation = transform.rotation.eulerAngles;
                        transform.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y, 180);
                        giro = false;
                        sentido = false;
                    }
                    else
                    {
                        transform.Rotate(Vector3.back * smooth);
                    }
                }
                else
                {
                    if ((transform.rotation.z <= 0.01 && transform.rotation.z > 0) || (transform.rotation.z >= -0.01 && transform.rotation.z < 0) || (transform.rotation.z == 0))
                    {
                        transform.Rotate(Vector3.back * 0);
                        giro = false;
                        sentido = true;
                        transform.rotation = posicaoInicial;
                    }
                    else
                    {
                        transform.Rotate(Vector3.back * smooth);
                    }
                }
            }

        }
        if (doABarrelRoll)
        {
            if ((transform.rotation.y == 1 || transform.rotation.y == -1) && flip == true && sentido==true)
            {
                transform.Rotate(Vector3.up * 0);
                Vector3 eulerRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(eulerRotation.x, 0, eulerRotation.z);
                doABarrelRoll = false;
                flip = false;
                SetImmortal();

            }
            if ((transform.rotation.y >= -0.01 && transform.rotation.y < 0) && flip == true && sentido == false)
            {
                transform.Rotate(Vector3.up * 0);
                Vector3 eulerRotation = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(eulerRotation.x, 0, eulerRotation.z); 
                doABarrelRoll = false;
                flip = false;
                SetImmortal();

            }
            else
            {
                LetDie();
                transform.Rotate(Vector3.up * smooth);
                flip = true;
            }
        }
        if (flip==true && highlander == false)
        {
            SetImmortal();
        }
        var step = moveSpeed * Time.deltaTime;
        var away = (-1* moveSpeed) * Time.deltaTime;
        if (side == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        if (side ==2)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
        if (side == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }
    }
    public void DoABarrelRoll() // ao entrar no trigger
    {
        if (giro == false)
        {
            if (Time.time > nextManover)
            {
                nextManover = Time.time + manoverRate;
                doABarrelRoll = true;
            }
        }
    }
    void animacaoAtaque() // animação do ataque saindo
    {
        animator.SetTrigger("Attack");
    }
    void SetImmortal() // animação do ataque saindo
    {
        highlander = true;
        immortal.enabled = true;
    }
    void LetDie() // animação do ataque saindo
    {
        highlander = false;
        immortal.enabled = false;
    }
    public void SetSide(int lado)
    {
        side = lado;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Hazard")
        {
            HitDirection(other);
        }

        if (other.tag == "PlayerAttack")
        {
            DoABarrelRoll();
            if (doABarrelRoll)
            {
                return;
            }
            else
            {
                Instantiate(explosion, other.transform.position, other.transform.rotation);
                Destroy(gameObject);
            }
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Hazard")
        {
            ExitDirection(collision);
        }
    }

    private void HitDirection(Collider2D collision)
    {
        if (transform.position.x - collision.transform.position.x > 0)
        {
            Debug.Log("Esquerda");
            SetSide(1);
        }
        if (transform.position.x - collision.transform.position.x < 0)
        {
            Debug.Log("Direita");
            SetSide(3);
        }
    }
    private void ExitDirection(Collider2D collision)
    {
        if (transform.position.x - collision.transform.position.x > 0)
        {
            Debug.Log("Esquerda");
            SetSide(2);
        }
        if (transform.position.x - collision.transform.position.x < 0)
        {
            SetSide(2);
            Debug.Log("Direita");
        }
    }
}