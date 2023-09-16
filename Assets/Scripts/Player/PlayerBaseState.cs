using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void OnSwitchState(PlayerStateManager player);
    public abstract void StateBehavior(PlayerStateManager player);
    public abstract void HandleCollision(PlayerStateManager player, Collision2D collider);
}
