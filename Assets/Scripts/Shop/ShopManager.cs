using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ShopManager : MonoBehaviour
{
    public ShopItem_SO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseButtons;
    public PlayerStats playerStats;

    public int rewardAmount;

    private void Start()
    {
        //Show Panels
        for (int i = 0; i < shopItemsSO.Length; i++)
            shopPanelsGO[i].gameObject.SetActive(true);
        LoadPanels();
        CheckPurchaseable();
    }

    public void LoadPanels() {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionText.text = shopItemsSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
            //TODO Set Images to shop items
        }
    }

    private void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            //TODO FIX
            //coins >= shopItemsSO[i].baseCost
            if (playerStats.GetPlayerCoins() >= shopItemsSO[i].baseCost)
            {
                myPurchaseButtons[i].interactable = true;

            }
            else
            {
                myPurchaseButtons[i].interactable = false;
            }
        }
    }


    public static event Action<int, int, int> onCoinAdded;
    public void AddCoins()
    {
        rewardAmount = 10;
        onCoinAdded?.Invoke((playerStats.GetPlayerGems() + rewardAmount), playerStats.GetPlayerGems(), playerStats.GetPlayerDiamonds());
        ////TODO Play Ad
        //coins++;
        //UpdateUI();

    }
}
