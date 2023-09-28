using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;

public class FastEnemy : BasicEnemy
{
    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyMovement = new Movement(this);
    }
    private void Start()
    {
        OnGameStart();
    }
    private void Update()
    {
        HandleMovement();
    }
    
}
