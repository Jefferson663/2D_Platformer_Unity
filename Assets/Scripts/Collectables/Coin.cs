using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject audioManager;
    private PlayerInventory player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerInventory>();
        audioManager = GameObject.FindGameObjectWithTag("audiomanager");
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            CoinCollected();
        }
    }
    private void CoinCollected(){
            player.TriggerCoinEvent();
            audioManager.GetComponent<AudioManager>().PlaySound("Coin");
            Destroy(gameObject);
    }
}
