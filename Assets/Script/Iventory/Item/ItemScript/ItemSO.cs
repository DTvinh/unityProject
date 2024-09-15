
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class ItemSO : ScriptableObject
{
    public int itemID;
    public string itemName;
    public ItemType type;
    public EquipmentType equipmentType;
    public Sprite image;
    [TextArea(15, 20)]
    public string description;
    public Rarity rarity;
    public ItemBuff[] buffs;

}

[System.Serializable]
public class ItemBuff
{

    public Attributes attribute;
    public int value;
}
public enum Attributes
{
    Agility,
    Stamina,
    Strngth,
    Hp,
    Mp
}
public enum EquipmentType
{
    None,
    Weapon,
    armor,
    hat,
    footwear,
    Ring,
    chain


}
public enum ItemType
{
    Fool,
    Equipment,
    Default
}
public enum Rarity
{


    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Divine
}