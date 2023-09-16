using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private int jumpCount;
    public override void OnSwitchState(PlayerStateManager player)
    {
        jumpCount = 2;
        Jump(player);
    }

    public override void StateBehavior(PlayerStateManager player)
    {
        HandleInputs(player);
        
    }

    public override void HandleCollision(PlayerStateManager player, Collision2D collider)
    {
        
    }
    
    private void Jump(PlayerStateManager player)
    {
        jumpCount = player.playerMovement.Jump(jumpCount);
    }
    private void HandleInputs(PlayerStateManager player)
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.playerMovement.MoveBodyWhileJumping(player.right);
            player.sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
           player.playerMovement.MoveBodyWhileJumping(player.left);
            player.sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            jumpCount = player.playerMovement.Jump(jumpCount);
    }
 
}
