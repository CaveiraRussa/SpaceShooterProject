using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// comando do Boss
public class BossBoundary : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int damage;
    private GameController gameController;
    private BossAreaDMG BossAreaDMG;
    public string newMap;

    public float hp;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); // verifica se o Controller existe
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
      
    }


    void OnTriggerEnter2D(Collider2D other) // ao entrar no trigger
    {
        if (other.tag == "Boundary")
        {
            return;

        }
        if (other.tag == "MainCamera")
        {
            return;
        }
        if (other.tag == "Background")
        {
            return;
        }
        if (other.tag == "Enemy")
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
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
        if (other.tag == "PlayerAttack") // se o ataque do jogador entrar na area ele diminui o hp do boss
        {
            Destroy(other.gameObject);
            hp = hp - damage;
            gameController.AddScore(damage);

            if (hp <= 0)// se o hp do boss zera, é destruido
            {

                Destroy(gameObject);
                SceneManager.LoadScene(newMap);
            }
        }

    }
}



