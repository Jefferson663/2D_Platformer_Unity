using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;

public class PlayerStateManager : MonoBehaviour
{
    //State stuff
    private PlayerBaseState currentState;

    public PlayerRunningState runningState = new PlayerRunningState();
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerJumpingState jumpingState = new PlayerJumpingState();

    //Stats stuff
    [Space]
    [Header("Movement")]
    [Space]
    [HideInInspector]public int right = 1;
    [HideInInspector]public int left = -1;
    public float velocity;
    public float jumpingPower = 5f;
    [Range(0f, 1f)] public float velocityWhenJumping = 0.7f;
    [Range(0f, 1f)] public float abruptStop = 0.4f;
    [Range(1f,2f)] public float runMultiplier;

    [HideInInspector] public Rigidbody2D playerBody;

    [Header("Sound")]
    public AudioManager audioManager;
    [Space]
    [Header("Sprite")]
    public SpriteRenderer sprite;

    //Player management stuff
    [HideInInspector]public Movement playerMovement;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerMovement = new Movement(playerBody, velocity, jumpingPower, velocityWhenJumping, abruptStop);
    }
    private void Start()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState.StateBehavior(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.HandleCollision(this, collision);
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.OnSwitchState(this);
    }
}
