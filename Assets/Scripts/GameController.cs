using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
// controla todo o jogo
public class GameController : MonoBehaviour
{
    public Text scoreText;
    private int score;
    private bool gameOver;
    private bool restart;
    //private PlayerController player;
    public Text gameOverText;
    public Text restartText;
    public Text specialText;
    // private int special;
    public string repeatMap;
    private bool endFlag;


    void Start()

    {
        // essa area tinha haver com o ataque especial do jogador, foi desativado por enquanto

        //GameObject playerObject = GameObject.FindWithTag("Player");
        // if (playerObject != null)
        // {
        //  player = playerObject.GetComponent<PlayerController>();
        // }
        // if (playerObject == null)
        // {
        //     Debug.Log("Cannot find 'PlayerController' script");
        // }
        gameOver = false; // mensagem de game over
        restart = false; // opção de restart
        endFlag = false;
        score = 0;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();
        //special = 0;
    }

    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (restart) // reseta a fase
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(repeatMap);

            }
        }
        if (gameOver) // iniciar a opção de resetar
        {

            restartText.text = "Press 'R' for Restart";
            restart = true;

        }
        //if (score > 0) // especial desativado
        //{
        //  special = score;
        // if (special >= 100)
        //{
        //   special = 0;
        //  player.Special();
        // }
        // }
    }
    public void AddScore(int newScoreValue) // pontos
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        endFlag = true;
    }

    public bool RaiseFlag()
    {
        if (endFlag)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}


