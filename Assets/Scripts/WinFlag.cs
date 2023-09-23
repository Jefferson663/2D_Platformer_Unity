using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinFlag : MonoBehaviour
{
    public event EventHandler OnPlayerWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player")){
            OnPlayerWin?.Invoke(this, EventArgs.Empty);
        }
    }
}
