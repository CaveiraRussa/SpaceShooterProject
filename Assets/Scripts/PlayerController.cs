using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// script do controle do jogador
public class PlayerController : MonoBehaviour
{
    public float speed;
    private Animator animator;
    
    private SpriteRenderer SpriteRenderer;
    private Rigidbody2D rb2d;

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

    private float nextFire;
   // private float nextFireS;
    void Start() // starta buscando o componentes
    {
        animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();

        //specialAtk = false;
        //specialText.text = "";
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire) // bloco para disparar os tiros
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            Instantiate(shot2, shotSpawn2.position, Quaternion.identity);
            animacaoAtaque();
            GetComponent<AudioSource>().Play();// ativa o som


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
       
        
            if (Input.GetKeyDown(KeyCode.Escape)) // fecha o jogo
            {
                Application.Quit();
            }
        
    }
    void FixedUpdate() // faz o movimentação
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;
       

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

}