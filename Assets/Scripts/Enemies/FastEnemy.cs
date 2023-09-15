using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;

public class FastEnemy : BasicEnemy
{
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyMovement = new Movement(enemyBody, runSpeed, direction);
    }
    private void Start()
    {
        OnGameStart();
    }
    private void Update()
    {
        HandleMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }
}
