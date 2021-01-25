using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardSpawn : MonoBehaviour
{
    private Transform player;
    private Spawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // testa se o objeto existe
        if (player == null)
        {
            Debug.Log("Cannot find 'player' script");
        }

        GameObject spawnObject = GameObject.FindWithTag("MovableSpawn");
        if (spawnObject != null)
        {
            spawn = spawnObject.GetComponent<Spawn>();
        }
        if (spawn == null)
        {
            Debug.Log("Cannot find 'spawn' script");
        }
        spawn.SetY(player.position.y + 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < 0)
        {
            spawn.SetY(20f);
        }
        else
        {
            spawn.SetY(player.position.y + 20f);
        }
    }
}
