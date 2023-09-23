using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void OnSwitchState(PlayerStateManager player)
    {
        player.spriteManager.RunAnimation();
        player.playerParticleSystem.SetActive(true);
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

        if (Input.GetKeyDown(KeyCode.Space)){
            player.playerParticleSystem.SetActive(false);
            player.SwitchState(player.jumpingState);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.playerMovement.MoveBody(player.right);
            player.spriteManager.spriteLookRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.playerMovement.MoveBody(player.left);
            player.spriteManager.spriteLookLeft();
        }

        else
        {
            player.SwitchState(player.idleState);
            player.playerParticleSystem.SetActive(false);
        }

    }
    
}
