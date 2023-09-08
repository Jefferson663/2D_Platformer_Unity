using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerBaseState currentState;

    public PlayerRunningState runningState = new PlayerRunningState();
    public PlayerIdleState idleState = new PlayerIdleState();
    public PlayerJumpingState jumpingState = new PlayerJumpingState();

    [Header("Player Health")]
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private GameObject UI;
    [SerializeField] private Image fullHeart;
    [SerializeField] private Image emptyHeart;
    [Space]
    [Header("Movement")]
    [Space]
    public float velocity;
    [Range(0f,1f)]public float velocityJumping = 0.7f;
    public float jumpingPower = 5f;
    [Range(0f, 1f)] public float abruptStop = 0.4f;
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
        HandleHealth();
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

    private void HandleHealth()
    {
        foreach (Transform t in UI.transform)
        {
            if(health > 0)
            {
                t.GetComponent<Image>().sprite = null;
                health--;
            }
            else
            {
                t.GetComponent<Image>().sprite = null;
            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
