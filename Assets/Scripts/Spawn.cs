using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector2 minXmaxX;
    public float y;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private GameController gameController;
    private bool endSpawn;
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
        StartCoroutine(SpawnWaves()); // iniciar o spawm dos inimigos
        endSpawn = false;
    }

    // Update is called once per frame
    IEnumerator SpawnWaves() //cria os asteroides
    {
        yield return new WaitForSeconds(startWait);
        while (!endSpawn)
        {
            for (int i = 0; i < hazardCount; i++) // iniciar a criação dos asteroids e mantem eles sendo spammados na area definida
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector2 spawnPosition = new Vector2(Random.Range(minXmaxX.x, minXmaxX.y), y); // seta a area definida
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation); // cria eles
                yield return new WaitForSeconds(spawnWait); // cooldown de criação
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
    void Update()
    {
        endSpawn = gameController.RaiseFlag();
    }

    public void SetY(float move)
    {
        y = move;
    }
}
