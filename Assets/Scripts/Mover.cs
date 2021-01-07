using UnityEngine;
using System.Collections;
// codigo basico de mover horizontalmente 
public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.up  * speed;

    }

}