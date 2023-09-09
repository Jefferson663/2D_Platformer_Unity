using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : BasicEnemy
{
    [SerializeField][Range(1, 5)] private int timeToJump;
    [SerializeField] private float jumpPower;
    private Rigidbody2D rb;
    private void Start()
    {
        HandleStart();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitToJump());
    }
    private void Update()
    {
        HandleMovement();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    protected override void HandleMovement()
    {
        transform.position += new Vector3(direction, 0) * runSpeed * Time.deltaTime;
    }

    private IEnumerator WaitToJump()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToJump);
            rb.velocity = new Vector3(rb.velocity.x, jumpPower);
        }
    }
}
