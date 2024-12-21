using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItemStat : ScriptableObject
{
    public string itemName;
    public InventoryType itemType;
    public string itemDescription;
    public Sprite itemIcon;
    public int itemRarity;
}

public enum InventoryType
{
    Armor,
    Axe,
    Skill_1,
    Skill_2,
    Spells,
    All
}
