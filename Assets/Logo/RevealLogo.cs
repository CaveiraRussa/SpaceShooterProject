﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealLogo : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;

    }

}
