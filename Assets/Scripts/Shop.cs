using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TMP_Text playerCoinsTxt;
    public Inventory inventory;

    [Space]
    public InventoryItemStat fireSpell;
    public InventoryItemStat poisonSpell;

    int playerCoins;

    private void Start()
    {
        playerCoins = 10000;
        playerCoinsTxt.text = playerCoins.ToString();
    }

    public void OnPurchaseFireSpell(int cost)
    {
        if (playerCoins < cost)
            return;

        else
        {
            playerCoins -= cost;
            playerCoinsTxt.text = playerCoins.ToString();
        }
        inventory.AddToInventory(fireSpell);


    }

    public void OnPurchasePoisonSpell(int cost)
    {
        if (playerCoins < cost)
            return;

        else
        {
            playerCoins -= cost;
            playerCoinsTxt.text = playerCoins.ToString();
        }

        inventory.AddToInventory(poisonSpell);
    }


}
