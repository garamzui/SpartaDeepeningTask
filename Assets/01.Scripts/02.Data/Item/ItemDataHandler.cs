using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataHandler : SingleTon<ItemDataHandler>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void TryEnchantItem(Item item) //아이템 강화시도 매서드
    {
        if (item.insEnchantPotencial == 0)
        {
            UIManager.Instance.SystemMessage("더 이상 강화가 불가능 합니다.");
            return;
        }
        if (item.insEnchantPotencial ==-1)
        {
            UIManager.Instance.SystemMessage("강화 불가능 아이템");
            return;
        }
        
        if (item.itemData is EquipmentItem equippedItem)
        {
            
            
           
            float enchantProbabilityPerLevel = 9 - item.insEnchantLevel;
            if (enchantProbabilityPerLevel <= 2)
            {
                enchantProbabilityPerLevel = 2;
            }

            float enchantProbability = Random.Range(0, 9);
            if (enchantProbability <= enchantProbabilityPerLevel)
            {
                SucessEnchantItem(item);
            }

            else
            { 
                item.insEnchantPotencial -=1;
                UIManager.Instance.SystemMessage("강화 실패!");
            }
        }
        else
        {
            Debug.Log("장비 아이템이 아닙니다.");
        }
    }

    private void SucessEnchantItem(Item item) //강화 성공시 매서드
    {
        if (item.itemData is EquipmentItem equippedItem)
        {
            item.insEnchantLevel += 1;
          
            if (equippedItem.itemType == EquipItemType.Weapon)
            {
               item.insEnchantedDamage += item.insEnchantLevel * (equippedItem.damage / 10f);
                UIManager.Instance.SystemMessage(
                    $"{equippedItem.itemName}이(가) 강화되어 {item.insDamage} + {item.insEnchantedDamage} 데미지를 가집니다.");
            }
            else if (equippedItem.itemType == EquipItemType.Armor)
            {
                item.insEnchantedDefense += item.insEnchantLevel * (equippedItem.defense / 10f);

                UIManager.Instance.SystemMessage(
                    $"{equippedItem.itemName}이(가) 강화되어 {item.insDefense} + {item.insEnchantedDefense} 방어력을 가집니다.");
            }
        }
    }

    public void UsingConsumeItem(Item item)
    {
        var gm = GameManager.Instance.Player.statHandler;
        if (!(item.itemData is ConsumableItem CI))
        {
            return;
        }


        else
        {
            gm.ModifyStat(StatType.Health, CI.valueAmount);
            UIManager.Instance.SystemMessage($"체력이{CI.valueAmount}만큼 회복되었습니다. ");
            if (gm.GetStat(StatType.Health) > gm.GetStat(StatType.MAXHealth))
            {
                gm.SetStat(StatType.Health, gm.GetStat(StatType.MAXHealth));
            }
        }
    }

    public void EquipItem(Item item)
    {
        if (!(item.itemData is EquipmentItem))
        {
            return;
        }

        var gm = GameManager.Instance.Player.statHandler;
       
            gm.ModifyStat(StatType.Damage, item.insDamage);
            gm.ModifyStat(StatType.EnchantedDamage, item.insEnchantedDamage);
        

        GameObject obj = Instantiate(item.itemData.itemPrefab, GameManager.Instance.Player.weaponPivot.transform);
        GameManager.Instance.Player.currentEquipmentWeapon = obj;
        GameManager.Instance.Player.currentEquipmentWeaponData = item;

        item.isEquipped = true;
        Debug.Log("아이템 장착");
    }

    public void UnEquipItem(Item item)
    {
        if (!(item.itemData is EquipmentItem))
        {
            return;
        }

        var gm = GameManager.Instance.Player.statHandler;
        gm.ModifyStat(StatType.Damage,- item.insDamage);
        gm.ModifyStat(StatType.EnchantedDamage,- item.insEnchantedDamage);

        Destroy(GameManager.Instance.Player.currentEquipmentWeapon);
        GameManager.Instance.Player.currentEquipmentWeapon = null;
        GameManager.Instance.Player.currentEquipmentWeaponData = null;


        item.isEquipped = false;
        Debug.Log("아이템 해제");
    }


    public void Stacked(Item item)
    {
        if (item.itemData is ResourceItem resourceItem)
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
        if (item.itemData is ResourceItem resourceItem)
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