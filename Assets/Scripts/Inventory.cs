using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Store all the items
    //Data of items - type, count, 
    List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public InventoryUI inventoryUI;
    [Header("Selection")]
    public GameObject selectedItemPanel;
    public TMP_Text selectedItemName;
    public TMP_Text selectedItemDescription;
    public Image selectedItemImg;
    [Space]
    public GameObject addedToInventoryTxt;

    public void AddToInventory(InventoryItemStat inventoryItem)
    {
        bool changed = false;
        foreach(var  item in inventoryItems)
        {
            if(item.itemStats.itemType == inventoryItem.itemType)
            {
                item.itemCount++;
                changed = true;
                break;
            }
        }

        if(!changed)
        {
            inventoryItems.Add(new InventoryItem(inventoryItem));
            changed = true;
        }

        if (changed)
        {
            inventoryUI.UpdateInventoryUI(inventoryItems);   
            ShowInventoryUpdateMsg();
        }
    }

    void ShowInventoryUpdateMsg()
    {
        addedToInventoryTxt.SetActive(true);
        Invoke(nameof(HideInventoryUpdateMsg), 1f);
    }
    void HideInventoryUpdateMsg()
    {
        addedToInventoryTxt.SetActive(false);
    }

    public void RemoveFromInventory(InventoryItemStat inventoryItem)
    {
        bool changed = false;
        foreach (var item in inventoryItems)
        {
            if (item.itemStats.itemType == inventoryItem.itemType)
            {
                item.itemCount--;
                if(item.itemCount == 0)
                {
                    inventoryItems.Remove(item);
                }
                changed = true;
                break;
            }
        }


        if (changed)
        {
            inventoryUI.UpdateInventoryUI(inventoryItems);
            ShowInventoryUpdateMsg();
        }
    }

    public void SetSelectedItem(InventoryItem inventoryItem)
    {
        selectedItemPanel.SetActive(true);

        selectedItemName.text = inventoryItem.itemStats.itemName;
        selectedItemDescription.text = inventoryItem.itemStats.itemDescription;
        selectedItemImg.sprite = inventoryItem.itemStats.itemIcon;
    }

    public void TabSelected(InventoryType inventoryType)
    {
        List<InventoryItem> selectedTypeItems = new List<InventoryItem>();

        if(inventoryType == InventoryType.All)
        {
            selectedTypeItems = inventoryItems;
        }
        else if(inventoryType == InventoryType.Spells)
        {
            foreach (var item in inventoryItems)
            {
                if (item.itemStats.itemType == InventoryType.Skill_1 || item.itemStats.itemType == InventoryType.Skill_2)
                {
                    selectedTypeItems.Add(item);
                }
            }
        }
        else
        {
            foreach (var item in inventoryItems)
            {
                if (item.itemStats.itemType == inventoryType)
                {
                    selectedTypeItems.Add(item);
                }
            }
        }

        inventoryUI.UpdateInventoryUI(selectedTypeItems);
    }
}


[System.Serializable]
public class InventoryItem
{
    public InventoryItemStat itemStats;
    public int itemCount;

    public InventoryItem(InventoryItemStat inventoryItemStat)
    {
        itemStats = inventoryItemStat;
        itemCount = 1;
    }
}