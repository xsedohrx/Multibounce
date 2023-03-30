using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Scriptable Objects/New Shop Item", fileName ="ShopMenu", order = 1)]
public class ShopItem_SO : ScriptableObject
{
    public string title;
    public string description;
    public int baseCost;
    public int gemCost;
    public Texture2D icon;

}
