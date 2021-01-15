using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// script do controle do jogador
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private float smooth = 5f;
    private bool giro;
    private bool sentido;
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rb2d;
    private Quaternion posicaoInicial;

    public GameObject shot;
    public Transform shotSpawn;
    public GameObject shot2;
    public Transform shotSpawn2;
    //public GameObject shot3;
   // public Transform shotSpawn3;
    public float fireRate;
    // public float fireRateS;
    //private bool specialAtk;
    //public Text specialText;
    private GameController gameController;
    public GameObject playerExplosion;
    private float nextFire;
   // private float nextFireS;
    void Start() // starta buscando o componentes
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        giro = false;
        sentido = true;
        posicaoInicial = transform.rotation;
        //specialAtk = false;
        //specialText.text = "";
    }
    void Update()
    {
        if (giro == false) 
        { 
            if (Input.GetButton("Fire1") && Time.time > nextFire) // bloco para disparar os tiros
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            Instantiate(shot2, shotSpawn2.position, Quaternion.identity);
            animacaoAtaque();
            GetComponent<AudioSource>().Play();// ativa o som


        }
    }
        // ataque especial desativado
        // if (specialAtk)
        //{

        //  if (Input.GetButton("Jump")&& Time.time > nextFireS)
        // {
        //   nextFireS = Time.time + fireRateS;
        // Instantiate(shot3, shotSpawn3.position, Quaternion.identity);
        // animacaoAtaque();
        // GetComponent<AudioSource>().Play();
        //specialAtk = false;
        //specialText.text = "";
        // }
        // }
        
    }
    void FixedUpdate() // faz o movimentação
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            giro = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape)) // fecha o jogo
        {
            Application.Quit();
        }

        if (giro)
        {
            if (sentido)
            {
                if (transform.rotation.z == -1f || transform.rotation.z == 1f)
                {
                    transform.Rotate(Vector3.back * 0);
                    Debug.Log(transform.rotation.z);
                    giro = false;
                    sentido = false;
                    rb2d.velocity = movement * speed;
                }
                else
                {
                    rb2d.velocity = movement * 0;
                    transform.Rotate(Vector3.back * smooth);
                }
            }
            else
            {
                if (transform.rotation.z <= 0.01 && transform.rotation.z > 0)
                {
                        transform.Rotate(Vector3.back * 0);
                        giro = false;
                        sentido = true;
                        transform.rotation = posicaoInicial;
                        rb2d.velocity = movement * speed;


                }
                else
                {
                    rb2d.velocity = movement * 0;
                    transform.Rotate(Vector3.back * smooth);
                }
            }
        }


        bool flipSprite = (SpriteRenderer.flipX ? (moveHorizontal > 0.01f) : (moveHorizontal < -0.01f)); // vira o sprite dependendo do lado que virar
        if (flipSprite)
        {
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }


    }

    void animacaoAtaque() // animação do ataque saindo
    {
        animator.SetTrigger("Attack");
    }
    //public void Special()
    //{
    //specialText.text = "Special Ready";
    //specialAtk = true;
    //}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyAttack" || other.tag == "Hazard")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.GameOver();
        }

    }
}