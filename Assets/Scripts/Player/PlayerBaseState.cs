using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void StartState(PlayerStateManager player);
    public abstract void UpdateState(PlayerStateManager player);
    public abstract void HandleCollision(PlayerStateManager player, Collision2D collider);
}
