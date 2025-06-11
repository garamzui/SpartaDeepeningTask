using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemData itemData;

    public int ID = 0;

    //장비 아이템용 가변 필드
    public bool isEquipped;
    public float insDamage;
    public float insDefense;
    public float insEnchantedDamage = 0;
    public float insEnchantedDefense = 0;
    public float insEnchantLevel = 0;
    public float insEnchantPotencial;

    public Item(ItemName name, int itemID)
    {
        if (DataManager.Instance.ItemsForName.TryGetValue(name, out var data))
        {
            itemData = data;
        }
        else
        {
            Debug.LogError($"[Item] '{name}'is Null");
        }

        if (itemData is EquipmentItem EI)
        {
            insDamage = EI.damage;
            insDefense = EI.defense;
            insEnchantPotencial = EI.enchantPotencial;
        }

        ID = itemID;
    }
}