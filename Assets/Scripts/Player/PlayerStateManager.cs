using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;

    public PlayerRunningState runningState = new PlayerRunningState();
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerJumpingState jumpingState = new PlayerJumpingState();

    [Header("Movement")]
    [Space]
    public float velocity = 1.0f;
    public Vector3 direction = new Vector3(1,0);


    private void Start()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.StartState(this);
    }
}
