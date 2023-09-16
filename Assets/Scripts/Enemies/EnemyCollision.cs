using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private BasicEnemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<BasicEnemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Floor"))
        {
            enemy.enemyMovement.TurnAround();
            enemy.CheckWhereToLook();
        }
    }
}
