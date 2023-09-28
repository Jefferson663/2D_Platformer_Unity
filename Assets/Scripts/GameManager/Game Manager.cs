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
    public void SetPlayerHealthToDefault(){
        PlayerPrefs.SetInt("PlayerHealth",3);
    }
    private void Awake(){
        player = GameObject.FindWithTag("player");
        goal.OnPlayerWin += SetPlayerValues;
        GetPlayerPrefValues();
    }
    private void SetPlayerValues(object sender, EventArgs e){
        PlayerPrefs.SetInt("PlayerCoins", player.GetComponent<CoinManager>().coinCounter);
        player.GetComponent<PlayerHealth>().SetPlayerPrefHealth();
    }
    private void GetPlayerPrefValues(){
        if(PlayerPrefs.GetInt("PlayerHealth", empty) != empty)
            player.GetComponent<PlayerHealth>().health  = PlayerPrefs.GetInt("PlayerHealth", 3);
        if(PlayerPrefs.GetInt("PlayerCoins", empty) != empty)
            player.GetComponent<CoinManager>().coinCounter = PlayerPrefs.GetInt("PlayerCoins");
    }
}
