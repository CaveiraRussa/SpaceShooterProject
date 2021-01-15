using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUp : MonoBehaviour
{
    private Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb2D;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform; // testa se o objeto existe
        if (player == null)
        {
            Debug.Log("Cannot find 'player' script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        if (direction.y < -20)
        {
            rb2D.velocity = transform.up * (-1 * moveSpeed);
        }
        if (direction.y > 20f)
        {
            rb2D.velocity = transform.up * moveSpeed;
        }

    }

}
