using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public Button[] tabBtns;

    public Inventory inventory;

    Button selectedBtn = null;

    public void OnEnterHoverTab(Button button)
    {
        if (selectedBtn == button)
            return;
        button.transform.DOScale(1.1f, 0.25f);
    }

    public void OnExitHoverTab(Button button)
    {
        if (selectedBtn == button)
            return;
        button.transform.DOScale(1f, 0.25f);
    }

    public void OnSelectTab(int index)
    {
        if(index == 0)
        {
            //All
            inventory.TabSelected(InventoryType.All);
        }
        else if(index == 1)
        {
            //Armor
            inventory.TabSelected(InventoryType.Armor);
        }
        else if (index == 2)
        {
            //Weapon;
            inventory.TabSelected(InventoryType.Axe);
        }
        else
        {
            //Abilities
            inventory.TabSelected(InventoryType.Spells);
        }

        foreach(var btn in  tabBtns)
        {
            btn.transform.DOScale(1, 0);
        }

        if (index != 0)
        {
            tabBtns[index].transform.DOScale(1.25f, 0.25f);
            selectedBtn = tabBtns[index];
        }
    }
}
