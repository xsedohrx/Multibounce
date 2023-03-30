using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
                    
    [SerializeField] private TMP_Text coinUI;
    [SerializeField] private TMP_Text gemUI;
    [SerializeField] private TMP_Text diamondUI;

    //TODO DECOUPLE!!!
    PlayerStats playerStats;

    private void OnEnable(){ ShopManager.onCoinAdded += UpdateUI; }
    private void OnDisable(){ ShopManager.onCoinAdded -= UpdateUI; }


    //Find the playerstats script and Update the UI
    private void Start()
    {
        //TODO DECOUPLE playerstats!!!!
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        UpdateUI(playerStats.GetPlayerCoins(), playerStats.GetPlayerGems(), playerStats.GetPlayerDiamonds()); 
    }

    //Set UI Values
    private void UpdateUI(int coins, int gems, int diamonds)
    {
        coinUI.text = "Coins: " + playerStats.GetPlayerCoins();
        gemUI.text = "Gems: " + playerStats.GetPlayerGems();
        diamondUI.text = "Diamonds: " + playerStats.GetPlayerDiamonds();
        
    }


}
