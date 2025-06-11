using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataHandler : SingleTon<ItemDataHandler>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void TryEnchantItem(Item item)//아이템 강화시도 매서드
    {
        if (item.itemData is EquipmentItem equippedItem)
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
                SucessEnchantItem(item);
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

    private void SucessEnchantItem(Item item)//강화 성공시 매서드
    {
        if (item.itemData is EquipmentItem equippedItem)
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

    public void EquipItem(Item item)
    {
        GameObject obj = Instantiate(item.itemData.itemPrefab, GameManager.Instance.Player.weaponPivot.transform);
       GameManager.Instance.Player.currentEquipmentWeapon = obj;
       GameManager.Instance.Player.currentEquipmentWeaponData = item;
       
           item.isEquipped = true;
           Debug.Log("아이템 장착");
       
    }

    public void UnEquipItem(Item item)
    {
      
           
       Destroy(GameManager.Instance.Player.currentEquipmentWeapon); 
       GameManager.Instance.Player.currentEquipmentWeapon =  null;
       GameManager.Instance.Player.currentEquipmentWeaponData = null;
       
           item.isEquipped = false;
           Debug.Log("아이템 해제");
       
    }

    public void ThrowItem()
    {
    }

    public void Stacked(Item item)
    {
        if (item.itemData is ResourceItem resourceItem  )
        {
            if (resourceItem.isStackable)
            {
                resourceItem.stackAmount += 1f;
            }

        }
        else if (item.itemData is ConsumableItem consumableItem)
        {
           if (consumableItem.isStackable)
               {
                consumableItem.stackAmount += 1f;
               }
        }

    }

    public void UnstackItem(Item item)
    {
        if (item.itemData is ResourceItem resourceItem  )
        {
            if (resourceItem.isStackable)
            {
                resourceItem.stackAmount -= 1f;
            }

        }
        else if (item.itemData is ConsumableItem consumableItem)
        {
            if (consumableItem.isStackable)
            {
                consumableItem.stackAmount -= 1f;
            }
        }
    }
}