using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform inventoryUI;
    public InventoryItemUI inventoryItemUI;

    public void UpdateInventoryUI(List<InventoryItem> _inventoryItems)
    {
        for(int i = 0; i < inventoryUI.childCount; i++)
        {
            Destroy(inventoryUI.GetChild(i).gameObject);
        }

        for(int i = 0; i < _inventoryItems.Count; i++)
        {
            var item = Instantiate(inventoryItemUI, inventoryUI);
            item.SetupItem(_inventoryItems[i]);
        }
    }
}
