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
        if(Input.GetKey(KeyCode.D))
        {
            player.transform.position += player.direction * player.velocity * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            player.transform.position -= player.direction * player.velocity * Time.deltaTime;
        }
        else
        {
            player.SwitchState(player.idleState);
        }
    }

    
}
