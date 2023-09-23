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
        player.spriteManager.JumpAnimation();
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
            player.spriteManager.spriteLookRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
           player.playerMovement.MoveBodyWhileJumping(player.left);
            player.spriteManager.spriteLookLeft();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            jumpCount = player.playerMovement.Jump(jumpCount);
    }
 
}
