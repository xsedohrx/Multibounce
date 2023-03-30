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
            shopPanels[i].image.sprite = shopItemsSO[i].icon;
            shopPanels[i].image.preserveAspect = true;
            //TODO Set Images to shop items
        }
    }

    private void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
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

    //If the player has enough Coins purchase item and remove money from the player then update ui.
    public void PurchaseItem(int btnNo) {
        if (playerStats.GetPlayerCoins() >= shopItemsSO[btnNo].baseCost)
        {
            onCoinAdded?.Invoke(playerStats.GetPlayerCoins() - shopItemsSO[btnNo].baseCost, playerStats.GetPlayerGems(), playerStats.GetPlayerDiamonds());
            CheckPurchaseable();
            //TODO Unlock Item
        }
    }


    public static event Action<int, int, int> onCoinAdded;
    public void AddCoins()
    {
        rewardAmount = 50;
        onCoinAdded?.Invoke((playerStats.GetPlayerCoins() + rewardAmount), playerStats.GetPlayerGems(), playerStats.GetPlayerDiamonds());
        CheckPurchaseable();
        ////TODO Play Ad


    }
}
