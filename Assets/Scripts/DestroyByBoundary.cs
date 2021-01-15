using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
  
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
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Start")
        {
            return;
        }
        if (other.tag == "Background")
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
        if (other.tag == "Special")
        {
            return;
        }
        if (other.tag == "Enemy")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.GameOver();
        }
        Destroy(other.gameObject);
    }
}