using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event EventHandler OnCoinCollected;
    public void TriggerCoinEvent(){
        OnCoinCollected?.Invoke(this, EventArgs.Empty);
    }
}