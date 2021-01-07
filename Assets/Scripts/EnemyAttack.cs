using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        animator = GetComponent<Animator>();

    }

    void Update()
    {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, Quaternion.identity);
                animacaoAtaque();
                GetComponent<AudioSource>().Play();
            }

    }

    void animacaoAtaque() // animação do ataque saindo
    {
        animator.SetTrigger("Attack");
    }
}
