using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarAttack : MonoBehaviour
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
    void OnTriggerExit2D(Collider2D other)
    {


    }
    
}
