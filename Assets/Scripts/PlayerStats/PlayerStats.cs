using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private void OnEnable(){ ShopManager.onCoinAdded += SetPlayerResources; }
    private void OnDisable(){ ShopManager.onCoinAdded -= SetPlayerResources; }

    //Save Player Data
    public void SetPlayerResources(int coins, int gems, int diamonds) {

        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("Gems", gems);
        PlayerPrefs.SetInt("Diamonds", diamonds);
        //DebugStats();

    }

    //Log player resources
    void DebugResources() {
        Debug.Log("Coins: " + PlayerPrefs.GetInt("Coins").ToString());
        Debug.Log("Gems: " + PlayerPrefs.GetInt("Gems").ToString());
        Debug.Log("Diamonds: " + PlayerPrefs.GetInt("Diamonds").ToString());
    }

    //Load player data
    public int GetPlayerCoins() { return PlayerPrefs.GetInt("Coins"); }
    public int GetPlayerGems(){ return PlayerPrefs.GetInt("Gems"); }
    public int GetPlayerDiamonds(){ return PlayerPrefs.GetInt("Diamonds"); }    
    
}
