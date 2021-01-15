using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIA : MonoBehaviour
{
    public Transform shooter;
    public Transform target;
    private float moveSpeed = 40f;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindWithTag("Enemy").transform; // testa se o objeto existe
        target = GameObject.FindWithTag("Player").transform; // testa se o objeto existe
        Vector3 direction = transform.position - shooter.position;
        if (shooter == null)
        {
            Debug.Log("Cannot find 'Enemy' script");
        }
        rb2D = GetComponent<Rigidbody2D>();
        Debug.Log(direction.y);
        if (direction.y >= 0)
        {
            rb2D.velocity = transform.up * moveSpeed;
        }
        if (direction.y <= 0)
        {
            rb2D.velocity = transform.up * (-1 * moveSpeed);
        }
    }

}