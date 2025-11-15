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
    void OnTriggerEnter2D(Collider2D other)
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
        if (other.tag == "Hazard")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            gameController.GameOver();
        }
    }
}