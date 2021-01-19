using UnityEngine;

public class BulletIA : MonoBehaviour
{
    public Transform shooter;
    public Transform target;
    private float moveSpeed = -40f;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.up * moveSpeed;
    }

}