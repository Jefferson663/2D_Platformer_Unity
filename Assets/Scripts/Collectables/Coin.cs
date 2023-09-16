using UnityEngine;

public class Coin : MonoBehaviour
{
    private Collectables coin = new Collectables
        (
        "Coin",
        "A coin that has no other use except to look at it :)"
        );
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            coin.PutInInventory();
            Destroy(gameObject);
        }
    }
}
