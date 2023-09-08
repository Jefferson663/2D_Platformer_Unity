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
    public float velocityJumping = 0.7f;
    public float jumpingPower = 5f;
    public float abruptStop = 0.4f;
    [Range(1f,2f)]public float runMultiplier;

    [HideInInspector] public Rigidbody2D rb;

    [Header("Sound")]
    public AudioManager audioManager;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.HandleCollision(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.StartState(this);
    }
}
