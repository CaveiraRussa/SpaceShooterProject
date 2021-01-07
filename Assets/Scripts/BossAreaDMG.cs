using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAreaDMG : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject shot2;
    public Transform shotSpawn2;
    public GameObject shot3;
    public Transform shotSpawn3;
    public float fireRate;
    private float nextFire;
    


    void Update()
    {

        
        
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, Quaternion.identity);
                Instantiate(shot2, shotSpawn2.position, Quaternion.identity);
                Instantiate(shot3, shotSpawn3.position, Quaternion.identity);

            }
        
    }

    
}
