using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaRadar : MonoBehaviour
{
    private EnemyAI enemy;

    void Start()
    {
        GameObject enemyObject = GameObject.FindWithTag("Enemy");
        if (enemyObject != null)
        {
            enemy = enemyObject.GetComponent<EnemyAI>();
        }
        if (enemy == null)
        {
            Debug.Log("Cannot find 'EnemyAI' script");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.tag == "Hazard")
        {
            HitDirection(collision);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Hazard")
        {
            ExitDirection(collision);
        }
    }

    private void HitDirection(Collider2D collision)
    {
        if(transform.position.x - collision.transform.position.x > 0)
        {
            Debug.Log("Esquerda");
            enemy.SetSide(1);
        }
        if (transform.position.x - collision.transform.position.x < 0)
        {
            Debug.Log("Direita");
            enemy.SetSide(3);
        }
    }
    private void ExitDirection(Collider2D collision)
    {
        if (transform.position.x - collision.transform.position.x > 0)
        {
            Debug.Log("Esquerda");
            enemy.SetSide(2);
        }
        if (transform.position.x - collision.transform.position.x < 0)
        {
            enemy.SetSide(2);
            Debug.Log("Direita");
        }
    }
}

