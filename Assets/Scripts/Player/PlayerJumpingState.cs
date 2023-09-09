using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private int jumpCount;
    public override void StartState(PlayerStateManager player)
    {
        jumpCount = 1;
        player.audioManager.PlaySound("jumpingSound");
        player.rb.velocity = new Vector3(player.rb.velocity.x, player.jumpingPower);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        HandleInputs(player);
        
    }

    public override void HandleCollision(PlayerStateManager player, Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Floor"))
        {
            player.SwitchState(player.runningState);
        }
    }

    private void HandleInputs(PlayerStateManager player)
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.rb.velocity = new Vector3(player.velocity * player.velocityJumping, player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.rb.velocity = new Vector3(-player.velocity * player.velocityJumping, player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumpCount > 0)
            {
                player.rb.velocity = new Vector3(player.rb.velocity.x, player.jumpingPower);
                player.audioManager.PlaySound("jumpingSound");
                jumpCount--;
            }
        }
    }
}
