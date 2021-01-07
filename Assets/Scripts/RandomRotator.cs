using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;
    private Rigidbody2D rb2d;
    
    void Start()
    {
      GetComponent<Rigidbody2D>().angularVelocity = Random.value * tumble;

    }
}
