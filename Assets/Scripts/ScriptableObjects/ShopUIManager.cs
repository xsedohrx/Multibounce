using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{
    public int coins;
    public int gems;
    public int diamonds;

    public TMP_Text coinUI;
    public TMP_Text gemUI;
    public TMP_Text diamondUI;

    PlayerStats playerStats;

    private void OnEnable(){ ShopManager.onCoinAdded += UpdateUI; }
    private void OnDisable(){ ShopManager.onCoinAdded -= UpdateUI; }

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        UpdateUI(PlayerPrefs.GetInt("Coins"), PlayerPrefs.GetInt("Gems"), PlayerPrefs.GetInt("Diamonds")); 
    }


    //public void AddCoins()
    //{
    //    //TODO Play Ad
    //    coins++;
    //    UpdateUI();

    //}



    //Set UI Values
    private void UpdateUI(int coins, int gems, int diamonds)
    {
        Debug.Log("Invoked SHOPMANAGER");
        coinUI.text = "Coins: " + playerStats.GetPlayerCoins();
        gemUI.text = "Gems: " + playerStats.GetPlayerGems();
        diamondUI.text = "Diamonds: " + playerStats.GetPlayerDiamonds();
        
    }


}
