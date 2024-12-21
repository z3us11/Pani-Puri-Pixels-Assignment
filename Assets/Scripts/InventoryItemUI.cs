using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemUI : MonoBehaviour
{
    public Image itemImg;
    public GameObject[] stars;
    public TMP_Text itemCount;
    public Button button;

    Inventory inventory;
    InventoryItem inventoryItem;

    private void Start()
    {
        inventory = FindAnyObjectByType<Inventory>();
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnItemClicked);
    }

    public void SetupItem(InventoryItem itemStat)
    {
        inventoryItem = itemStat;

        itemImg.sprite = itemStat.itemStats.itemIcon;
        foreach(var star in stars)
        {
            star.SetActive(false);
        }
        for(int i = 0; i < itemStat.itemStats.itemRarity; i++)
        {
            stars[i].SetActive(true);
        }
        itemCount.text = itemStat.itemCount.ToString();
    }

    public void OnItemClicked()
    {
        inventory.SetSelectedItem(inventoryItem);

    }
}
