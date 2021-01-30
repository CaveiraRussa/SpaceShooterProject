using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfSight : MonoBehaviour
{
    void Start()
    {
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
