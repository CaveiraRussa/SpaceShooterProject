using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Codigo de destruir
public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private Rigidbody2D rb2D;
    private float thrust = 10.0f;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); // testa se o objeto existe
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        rb2D = GetComponent<Rigidbody2D>();

    }
    void OnTriggerEnter2D(Collider2D other) // ao entrar no trigger
    {
        if (other.tag == "Boundary") // não faz nada, Boundary é a area que se o objeto sair é destruido
        {
            return;
            
        }
        if (other.tag == "MainCamera")
        {
            return;
        }
        
        if (other.tag == "Boss")
        {
            return;
        }
        if (other.tag == "EnemyAttack")
        {
            return;

        }
        if (other.tag == "Hazard")// Hazard são os meteoros
        {
            rb2D.AddForce(transform.up * thrust);
            return;
        }

        if (other.tag == "PlayerAttack")
        {
            Destroy(other.gameObject);

            gameController.AddScore(scoreValue);

        }

        if (other.tag == "Background")
        {
            return;
        }
        Instantiate(explosion, transform.position, Quaternion.identity);
        if (other.tag == "Player") // se for o jogador destroi e manda o comando pro Controller
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        Destroy(other.gameObject); // destroi todo o resto que entrar
        Destroy(gameObject);
    }
}
	

