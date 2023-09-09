using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health")]
    [SerializeField] private int health = 3;
    [SerializeField] private int maxHealth = 3;
    private int UIhealth;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Update()
    {
        HandleHealth();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("heal"))
        {
            Heal(1);
        }
        if (collision.collider.CompareTag("enemy"))
        {
            TakeDamage(1);
        }
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
    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            UI.SetActive(false);
            gameOverScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void Heal(int heal)
    {
        health += heal;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
