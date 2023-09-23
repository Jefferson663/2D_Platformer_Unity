using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int empty = -1;
    public PlayerConfig playerConfigs;
    [SerializeField]private WinFlag goal;
    private GameObject player;
    private void Awake(){
        goal.OnPlayerWin += SetPlayerValues;
        GetPlayerPrefValues();
        SetPlayerValues();
    }
    private void SetPlayerValues(){
        player = GameObject.FindWithTag("player");
        player.GetComponent<PlayerHealth>().health = playerConfigs.playerLife;
        player.GetComponent<CoinManager>().coinCounter = playerConfigs.playerCoins;
    }
    private void SetPlayerValues(object sender, EventArgs e){
        player = GameObject.FindWithTag("player");
        player.GetComponent<PlayerHealth>().health = playerConfigs.playerLife;
        player.GetComponent<CoinManager>().coinCounter = playerConfigs.playerCoins;
    }
    private void GetPlayerPrefValues(){
        if(PlayerPrefs.GetInt("PlayerHealth", empty) != empty)
            playerConfigs.playerLife = PlayerPrefs.GetInt("PlayerHealth");
        if(PlayerPrefs.GetInt("PlayerCoins", empty) != empty)
            playerConfigs.playerCoins = PlayerPrefs.GetInt("PlayerCoins");
    }
}
