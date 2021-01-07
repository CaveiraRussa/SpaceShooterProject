using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCod : MonoBehaviour {
    private Rigidbody2D rb2d;
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

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
            return;

        }
        if (other.tag == "EnemyAttack")
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
        if (other.tag == "Background")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
        if (other.tag == "PlayerAttack")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);


        }

    }
}
