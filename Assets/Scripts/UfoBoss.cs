using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoBoss : MonoBehaviour {
    private Rigidbody2D rb2d;
    public GameObject explosion;
    public GameObject playerExplosion;
    public int damage;
    private GameController gameController;
    private BossAreaDMG BossAreaDMG;

    public float hp;
    

   
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
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        if (other.tag == "PlayerAttack")
        {
            Destroy(other.gameObject);
            hp = hp - 1;
            damage =+ 1;
           

            gameController.AddScore(damage);
        }
        Destroy(other.gameObject);
        if (hp == 0) { 
            Destroy(gameObject);
         }
    }
   


}
