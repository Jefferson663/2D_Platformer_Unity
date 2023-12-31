using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;

public class JumpingEnemy : BasicEnemy
{
    [SerializeField][Range(1, 5)] private int timeToJump;
    public float jumpPower;

    private void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyMovement = new Movement(this);
    }
    private void Start()
    {
        OnGameStart();
        StartCoroutine(WaitToJump());
    }
    private void Update()
    {
        HandleMovement();
    }
    protected override void HandleMovement()
    {
        enemyMovement.MoveBody();
    }

    private IEnumerator WaitToJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToJump);
            enemyMovement.Jump();
        }
    }
}
