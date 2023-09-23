using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Behavior.Movement;
using Behavior.SpriteManager;

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
    public float velocity;
    public float jumpingPower = 5f;
    [HideInInspector]public int right = 1;
    [HideInInspector]public int left = -1;
    [Range(0f, 1f)] public float velocityWhenJumping = 0.7f;
    [Range(0f, 1f)] public float abruptStop = 0.4f;

    [HideInInspector] public Rigidbody2D playerBody;

    [Header("Sound")]
    public AudioManager audioManager;

    [Header("Sprites")]
    private Animator animator;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private string hurtTag;
    [SerializeField] private string jumpTag;
    [SerializeField] private string runTag;

    //Player management stuff
    [HideInInspector]public Movement playerMovement;
    [HideInInspector] public ManageSprites spriteManager;

    public GameObject playerParticleSystem;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        playerMovement = new Movement(playerBody, velocity, abruptStop, jumpingPower, velocityWhenJumping, audioManager);
        spriteManager = new ManageSprites(spriteRenderer, animator, jumpTag, hurtTag, runTag);
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
    public void NotJumping()
    {
        SwitchState(this.runningState);
        spriteManager.EndJumpAnimation();
    }
    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        currentState.OnSwitchState(this);
    }
}
