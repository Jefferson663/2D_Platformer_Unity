using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void OnSwitchState(PlayerStateManager player)
    {
       
    }

    public override void StateBehavior(PlayerStateManager player)
    {
        HandleInputs(player);
    }

    public override void HandleCollision(PlayerStateManager player, Collision2D collider)
    {
        
    }

    private void HandleInputs(PlayerStateManager player)
    {

        if (Input.GetKeyDown(KeyCode.Space))
            player.SwitchState(player.jumpingState);

        else if (Input.GetKey(KeyCode.D))
        {
            player.playerMovement.MoveBody(player.right);
            player.sprite.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.playerMovement.MoveBody(player.left);
            player.sprite.flipX = false;
        }

        else
            player.SwitchState(player.idleState);
    }
    
}
