using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using Behavior.SpriteManager;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerStateManager player;
    [SerializeField] private ManageSprites manageSprites;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            player.NotJumping();
        }
    }
}
