using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageCoolDown = 2;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;
    private int UIhealth;
    private bool canTakeDamage = true;
    private PlayerStateManager player;

    private void Awake(){
        player = GetComponent<PlayerStateManager>();
    }

    private void Start()
    {
        HandleHealth();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("heal"))
        {
            Heal(1);
            HandleHealth();
        }
        if (collision.collider.CompareTag("enemy") && canTakeDamage)
        {
            CollideWithEnemy();
            HandleHealth();
        }
    }

    private IEnumerator DamageCoolDown()
    {
        yield return new WaitForSeconds(damageCoolDown);
        canTakeDamage = true;
        player.spriteManager.EndHurtAnimation();
    }
    private void HandleHealth()
    {
        UIhealth = health;

        foreach (Transform t in UI.transform)
        {
            if (UIhealth > 0)
            {
                t.GetComponent<Image>().sprite = fullHeart;
                UIhealth--;
            }
            else
            {
                t.GetComponent<Image>().sprite = emptyHeart;
            }

        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            UI.SetActive(false);
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
    private void Heal(int heal)
    {
        health += heal;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CollideWithEnemy(){
            TakeDamage(1);
            canTakeDamage = false;
            player.spriteManager.HurtAnimation();
            StartCoroutine(DamageCoolDown());
    } 
}
