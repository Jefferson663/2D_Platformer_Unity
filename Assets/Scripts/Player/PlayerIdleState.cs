using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void StartState(PlayerStateManager player)
    {
        player.rb.velocity = new Vector3(player.rb.velocity.x * player.abruptStop, player.rb.velocity.y);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        HandleInputs(player);
    }

    public override void HandleCollision(PlayerStateManager player, Collision2D collider)
    {
        
    }

    private void HandleInputs(PlayerStateManager player)
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            player.SwitchState(player.runningState);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.jumpingState);
        }
        
    }
}
