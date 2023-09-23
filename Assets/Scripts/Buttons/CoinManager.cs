using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterCanvas;
    [SerializeField] private PlayerInventory player;
    [HideInInspector] public int coinCounter = 0;
    private void Awake(){
        player.OnCoinCollected += UpdateCoins;
        UpdateCoins();
    }
    private void UpdateCoins(){
        coinCounterCanvas.text = coinCounter.ToString();
    }
    private void UpdateCoins(object sender, EventArgs e){
        coinCounter++;
        coinCounterCanvas.text = coinCounter.ToString();
    }
    private void SetPlayerPrefCoins(){
        PlayerPrefs.SetInt("PlayerCoins", coinCounter);
    }
}
