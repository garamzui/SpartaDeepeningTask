using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataHandler : MonoBehaviour
{
    public ItemData itemData ;

    public void TryEnchantItem()//아이템 강화시도 매서드
    {
        if (itemData is EquipmentItem equippedItem)
        {
            if (!equippedItem.isEnchantable)
            {
                Debug.Log("이건 강화 못해 이 짜식아"); //추후 UI추가해서 텍스트에 얹기
                return;
            }

            float enchantProbabilityPerLevel = 9 - equippedItem.enchantLevel;
            float enchantProbability = Random.Range(0, 9);
            if (enchantProbability <= enchantProbabilityPerLevel)
            {
                SucessEnchantItem();
            }

            else
            {
                Debug.Log("실패다 짜식아");
            }
        }
        else
        {
            Debug.Log("장비 아이템이 아닙니다.");
        }
    }

    private void SucessEnchantItem()
    {
        if (itemData is EquipmentItem equippedItem)
        {
            equippedItem.enchantLevel += 1;
            
            if (equippedItem.itemType == EquipItemType.Weapon)
            {
                equippedItem.enchantedDamage += equippedItem.enchantLevel * (equippedItem.damage / 10f);
                Debug.Log(
                    $"{equippedItem.itemName}이(가) 강화되어 {equippedItem.damage + equippedItem.enchantedDamage} 데미지를 가집니다.");
            }
            else if (equippedItem.itemType == EquipItemType.Armor)
            {
                equippedItem.enchantedDefense += equippedItem.enchantLevel * (equippedItem.defense / 10f);
                Debug.Log(
                    $"{equippedItem.itemName}이(가) 강화되어 {equippedItem.damage + equippedItem.enchantedDefense} 방어력을 가집니다.");
            }
        }
    }

    public void ConsumeItem()
    {
    }

    public void EquipItem()
    {
    }

    public void UnEquipItem()
    {
    }

    public void ThrowItem()
    {
    }

    public void Stacked()
    {
        if (itemData is ResourceItem resourceItem  )
        {
            if (resourceItem.isStackable)
            {
                resourceItem.stackAmount += 1f;
            }

        }
        else if (itemData is ConsumableItem consumableItem)
        {
           if (consumableItem.isStackable)
               {
                consumableItem.stackAmount += 1f;
               }
        }

    }

    public void UnstackItem()
    {
        if (itemData is ResourceItem resourceItem  )
        {
            if (resourceItem.isStackable)
            {
                resourceItem.stackAmount -= 1f;
            }

        }
        else if (itemData is ConsumableItem consumableItem)
        {
            if (consumableItem.isStackable)
            {
                consumableItem.stackAmount -= 1f;
            }
        }
    }
}