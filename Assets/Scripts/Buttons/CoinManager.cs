using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterCanvas;
    [SerializeField] private PlayerInventory player;
    private int coinCounter = 0;
    private void Awake(){
        player.OnCoinCollected += UpdateCoins;
    }
    private void UpdateCoins(object sender, EventArgs e){
        coinCounter++;
        coinCounterCanvas.text = coinCounter.ToString();
    }
}
