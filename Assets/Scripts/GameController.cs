using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
// controla todo o jogo
public class GameController : MonoBehaviour {
    public GameObject[] hazards;
    public GameObject[] enemys;

    private Vector2 spawnValues;
    public int hazardCount;
    public int enemyCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
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
        score = 0;
        gameOverText.text = "";
        restartText.text = "";
        UpdateScore();
        StartCoroutine (SpawnWaves()); // iniciar o spawm dos inimigos
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



    IEnumerator SpawnWaves() //cria os asteroides
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < hazardCount; i++) // iniciar a criação dos asteroids e mantem eles sendo spammados na area definida
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                GameObject Enemys = enemys[Random.Range(0, enemys.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(-18, 21), 520); // seta a area definida
                Vector2 spawnEnemyPosition = new Vector2(Random.Range(-18, 21), -20); // seta a area definida
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                Instantiate(Enemys, spawnEnemyPosition, spawnRotation);// cria eles
                yield return new WaitForSeconds(spawnWait); // cooldown de criação
            }
            yield return new WaitForSeconds(waveWait);
        }
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
    }


}   


