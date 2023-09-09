using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected float runSpeed = 2;
    [SerializeField] [Range(-1,1)] protected int direction = -1;
    protected SpriteRenderer sprite;

    protected void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        if(direction == 1)
        {
            CheckDirection();
        }
    }
    protected void Update()
    {
        transform.position += new Vector3(direction,0) * runSpeed * Time.deltaTime;
    }
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    protected virtual void HandleCollision(Collision2D collision)
    {
        if(collision.collider.CompareTag("wall"))
        {
            direction *= -1;
            CheckDirection();
        }
    }

    protected virtual void CheckDirection()
    {
        if(direction == 1)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }
}
