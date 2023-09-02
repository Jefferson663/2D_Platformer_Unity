using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void StartState(PlayerStateManager player)
    {
        
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.jumpingState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.rb.velocity = new Vector3(player.velocity, player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.rb.velocity = new Vector3(-player.velocity,player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            player.SwitchState(player.idleState);
        }
    }
    
}
