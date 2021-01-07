using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransitionBG : MonoBehaviour {

    public string newMap;
    private GameController gameController;

    // Use this for initialization
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
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(newMap);
        }
    }
}
