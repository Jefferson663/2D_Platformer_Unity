using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : BasicEnemy
{
    private void Start()
    {
        HandleStart();
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
