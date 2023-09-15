using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected float runSpeed = 2;
    [SerializeField] [Range(-1,1)] protected int direction = -1;
    private int right = 1;
    protected SpriteRenderer sprite;

    protected Rigidbody2D enemyBody;
    protected Movement enemyMovement;

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

    protected virtual void OnGameStart()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        CheckWhereToLook();
    }
    protected virtual void HandleMovement()
    {
        enemyMovement.MoveBody();
    }
    protected virtual void HandleCollision(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            enemyMovement.TurnAround();
            CheckWhereToLook();
        }
    }

    protected virtual void CheckWhereToLook()
    {
        if(enemyMovement.CheckDirection() == right)
            sprite.flipX = true;
        else
            sprite.flipX = false;
    }
}
