using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    private float walkSpeed;
    private float runSpeed;
    public override void StartState(PlayerStateManager player)
    {
        walkSpeed = player.velocity;
        runSpeed = player.velocity * player.runMultiplier;
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
        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkSpeed = runSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.SwitchState(player.jumpingState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.rb.velocity = new Vector3(walkSpeed, player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.rb.velocity = new Vector3(-walkSpeed,player.rb.velocity.y);
            player.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        else
        {
            player.SwitchState(player.idleState);
        }
    }
    
}
