using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquippedItem", menuName = "ItemDatas/EquippedItem")]
public class EquippedItem : ItemData
{
    public EquipItemType itemType;
    public float damage;
    public float defense;
    public bool isEquipped;
    public bool isEnchantable;
    public float enchantedDamage;
    public float enchantedDefense;
    public float enchantLevel;
    public float price;
    public bool isTradable;
}
