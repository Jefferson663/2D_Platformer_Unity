using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] protected float runSpeed;
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
    private void Update()
    {
        transform.position += new Vector3(direction,0) * runSpeed * Time.deltaTime;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    public virtual void HandleCollision(Collision2D collision)
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
