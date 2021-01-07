using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// codigo basico de mover horizontalmente 
public class EnemyMove : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private Vector2 startMovement;
    private float nextMove;
    private float newMove;
    private float movement;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up * speed;
        startMovement = rb2d.velocity;
        newMove = Random.Range(0, 10);
    }

    void FixedUpdate()
    {
        if (Time.time > nextMove)
        {
            nextMove = Time.time + newMove;
            if(newMove % 2 == 0)
            {
                 movement = 5;
            }
            else
            {
                 movement = -5;
            }
            startMovement.x = movement;
            rb2d.velocity = startMovement;
        }
    }
}