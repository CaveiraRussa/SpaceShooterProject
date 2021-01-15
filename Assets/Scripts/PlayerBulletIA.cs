using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletIA : MonoBehaviour
{
    public Transform shooter;
    public float moveSpeed = 5f;
    private Rigidbody2D rb2D;
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;
    // Start is called before the first frame update
    void Start()
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

        shooter = GameObject.FindWithTag("Player").transform; // testa se o objeto existe
        if (shooter == null)
        {
            Debug.Log("Cannot find 'Player' script");
        }
        rb2D = GetComponent<Rigidbody2D>();
        if (shooter.rotation.z == 1 || shooter.rotation.z == -1)
        {
            rb2D.velocity = transform.up * moveSpeed;
        }
        else
        {
            rb2D.velocity = transform.up * (-1 * moveSpeed);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Start")
        {
            return;
        }
        if (other.tag == "Boundary")
        {
            return;

        }
        if (other.tag == "Enemy")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            return;

        }
        if (other.tag == "EnemyAttack")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
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
        if (other.tag == "Background")
        {
            return;
        }
        if (other.tag == "Player")
        {
            return;

        }
        if (other.tag == "PlayerAttack")
        {
            return;

        }

    }
}