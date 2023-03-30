using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private void OnEnable()
    {
        ShopManager.onCoinAdded += SetPlayerStats;
    }
    private void OnDisable()
    {
        ShopManager.onCoinAdded -= SetPlayerStats;
    }


    //Save Player Data
    public void SetPlayerStats(int coins, int gems, int diamonds) {

        PlayerPrefs.SetInt("Coins", GetPlayerCoins() + coins);
        PlayerPrefs.SetInt("Gems", gems);
        PlayerPrefs.SetInt("Diamonds", diamonds);
        DebugStats();

    }

    void DebugStats() {
        Debug.Log("Coins: " + PlayerPrefs.GetInt("Coins").ToString());
        Debug.Log("Gems: " + PlayerPrefs.GetInt("Gems").ToString());
        Debug.Log("Diamonds: " + PlayerPrefs.GetInt("Diamonds").ToString());
    }

    //Load player data
    public int GetPlayerCoins() { return PlayerPrefs.GetInt("Coins"); }
    public int GetPlayerGems(){ return PlayerPrefs.GetInt("Gems"); }
    public int GetPlayerDiamonds(){ return PlayerPrefs.GetInt("Diamonds"); }    
    
}
