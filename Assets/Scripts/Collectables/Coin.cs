using UnityEngine;

public class Coin : MonoBehaviour
{
    private Collectables coin = new Collectables
        (
        "Coin",
        "A coin that has no other use except to look at it :)"
        );
    private GameObject audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audiomanager");
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            coin.PutInInventory();
            audioManager.GetComponent<AudioManager>().PlaySound("Coin");
            Destroy(gameObject);
        }
    }
}
