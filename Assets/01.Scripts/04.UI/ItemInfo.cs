using System;
using NaughtyAttributes.Test;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public Slot slot;

    //공통 아이템 필드
    public Image icon;
    public GameObject stackAmount;
    public GameObject equipped;
    public GameObject equipButton;
    public TextMeshProUGUI equipButtonText;
    public GameObject usingButton;
    public GameObject throwButton;
    public GameObject enchantButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemUseableLevel;
    public TextMeshProUGUI tradable;
    public TextMeshProUGUI itemPrice;
    public TextMeshProUGUI itemEnchantable;
    public TextMeshProUGUI itemEnchantPotencial;
    public TextMeshProUGUI itemEnchantLevel;
    public TextMeshProUGUI itemGrade;
//타입별 아이템 필드
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemValue1;
    public TextMeshProUGUI itemValue2;

    public void InfoWIndowOnAndOff()
    {
        if (this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(false);
            ResetInfo();

            slot = null;
        }
        else if (!this.gameObject.activeInHierarchy)
        {
            this.gameObject.SetActive(true);

            InitSetInfo();
        }
    }

    public void InitSetInfo()
    {
        Debug.Log(
            $"[CHECK] itemData 타입: {slot.item.itemData.GetType().Name}, 이름: {slot.item.itemData.itemDataName}, ID:{slot.item.ID}");
        icon.sprite = slot.item.itemData.icon;
        itemName.text = slot.item.itemData.itemName;
        itemDescription.text = slot.item.itemData.description;

        if (slot.item.itemData.useAbleLevel > GameManager.Instance.Player.statHandler.GetStat(StatType.Level))
        {
            itemUseableLevel.text = $"<color=#FF0000>사용 가능 Lv : {slot.item.itemData.useAbleLevel.ToString()}</color>";
        }
        else
        {
            itemUseableLevel.text = $"사용 가능 Lv : {slot.item.itemData.useAbleLevel.ToString()}";
        }

        if (slot.item.itemData.isTradable)
        {
            tradable.text = "거래가능";
        }
        else
        {
            tradable.text = "거래 불가능";
        }

        itemPrice.text = $"가격 : {slot.item.itemData.price}원";

        if (slot.item.itemData is EquipmentItem EI)
        {
            if (slot.item.insEnchantPotencial <= 0)
            {
                itemEnchantable.text = "<color=#FF0000>강화불가능</color>";
            }
            else
            {
                itemEnchantable.text = $"강화가능";
            }

            if (slot.item.insEnchantPotencial == 0)
            {
                itemEnchantPotencial.text = "<color=#FF0000>포텐셜 : 0</color>";
            }
            else if (slot.item.insEnchantPotencial > 0)
            {
                itemEnchantPotencial.text = $"포텐셜 : {slot.item.insEnchantPotencial.ToString()}";
            }
            else
            {
                itemEnchantPotencial.text = string.Empty;
            }

            float level = slot.item.insEnchantLevel;
            float potential = slot.item.insEnchantPotencial;

            if (potential == -1)
            {itemEnchantLevel.text = string.Empty;}
            else if (level == 0)
            {  itemEnchantLevel.text = "+0";}
            else
            {  itemEnchantLevel.text = $"<color={GetEnchantColor(level)}>+{level}</color>";}

            if (potential == -1)
            {itemGrade.text = "고유";}
            else if (level == 0)
            {  itemGrade.text = "커먼";}
            else
            {  itemGrade.text = $"<color={GetEnchantColor(level)}>등급 : {GetGradeName(level)}</color>";}

            itemType.text = $" 타입 : {EI.itemType.ToString()}";
            if (slot.item.insEnchantLevel == 0)
            {
                itemValue1.text = $"공격력 : {slot.item.insDamage} ";
                itemValue2.text = $"방어력 : {slot.item.insDefense}";
            }
            else
            {
                if (EI.itemType == EquipItemType.Weapon)
                {
                    itemValue1.text =
                        $"공격력 : {slot.item.insDamage} + <color=#00FFFF>{slot.item.insEnchantedDamage}</color>";
                    itemValue2.text = $"방어력 : {slot.item.insDefense}";
                }
                else if (EI.itemType == EquipItemType.Armor)
                {
                    itemValue1.text = $"공격력 : {slot.item.insDamage} ";
                    itemValue2.text =
                        $"방어력 : {slot.item.insDefense}+ <color=#00FFFF>{slot.item.insEnchantedDefense}</color>";
                }
            }

            usingButton.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(true);
            enchantButton.gameObject.SetActive(true);
            if (slot.item.isEquipped)
            {
                equipButtonText.text = "장착해제";
                equipped.SetActive(true);
            }
            else
            {
                equipButtonText.text = "장착";
                equipped.SetActive(false);
            }

            equipButton.gameObject.SetActive(true);
        }

        if (slot.item.itemData is ConsumableItem CI)
        {
            itemType.text = $" 타입 : {CI.itemType.ToString()}";
            itemValue1.text = $"회복량 : {CI.valueAmount}";
            itemValue2.text = string.Empty;
            usingButton.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(false);
            enchantButton.gameObject.SetActive(false);
            if (CI.isStackable)
            {
                stackAmount.SetActive(true);
            }
            else
            {
                stackAmount.SetActive(false);
            }
        }

        if (slot.item.itemData is ResourceItem RI)
        {
            itemType.text = $" 타입 : {RI.itemType.ToString()}";
            itemValue1.text = string.Empty;
            itemValue2.text = string.Empty;
            equipButton.gameObject.SetActive(false);
            enchantButton.gameObject.SetActive(false);
            if (RI.isStackable)
            {
                stackAmount.SetActive(true);
            }
            else
            {
                stackAmount.SetActive(false);
            }
        }
    }
    private string GetEnchantColor(float level) //GPT가 제안해준 매서드 리팩터링 
    {
        if (level < 4) return "#32CD32";
        if (level < 7) return "#9400D3";
        if (level < 10) return "#FF00FF";
        if (level < 13) return "#FFD700";
        return "#7FFFD4";
    }private string GetGradeName(float level)
    {
        if (level < 4) return "언커먼";
        if (level < 7) return "레어";
        if (level < 10) return "유니크";
        if (level < 13) return "에픽";
        return "태초";
    }

    private void ResetInfo()
    {
        // 아이콘 제거
        icon.sprite = null;

        // 텍스트 초기화
        itemName.text = "";
        itemDescription.text = "";
        itemUseableLevel.text = "";
        itemType.text = "";
        itemValue1.text = "";
        itemValue2.text = "";
        itemPrice.text = "";
        tradable.text = "";

        // 스택 수량 표시 비활성화
        stackAmount.SetActive(false);

        // 장착 상태 관련 요소 비활성화
        equipped.SetActive(false);
        equipButton.SetActive(false);

        // 버튼 텍스트 초기화
        equipButtonText.text = "";
    }

    public void OnConsumItem()
    {
        if (slot.item.itemData.useAbleLevel > GameManager.Instance.Player.statHandler.GetStat(StatType.Level))
        {
            UIManager.Instance.SystemMessage("레벨이 부족합니다.");
            return;
        }
        else if (GameManager.Instance.Player.statHandler.GetStat(StatType.Health) ==
                 GameManager.Instance.Player.statHandler.GetStat(StatType.MAXHealth))
        {
            UIManager.Instance.SystemMessage($"이미 최대 체력입니다. ");
            return;
        }

        ItemDataHandler.Instance.UsingConsumeItem(slot.item);
        slot.ONDestroySlot();
        UIManager.Instance.inventory.SetDefaultSlotCount();
        UIManager.Instance.statusPreView.TextReFresh();
    }

    public void OnInfoEquipItem()
    {
        var gm = GameManager.Instance.Player.currentEquipmentWeaponData;


        if (gm == null)
        {
            if (slot.item.itemData.useAbleLevel > GameManager.Instance.Player.statHandler.GetStat(StatType.Level))
            {
                UIManager.Instance.SystemMessage("레벨이 부족합니다.");
                return;
            }

            ItemDataHandler.Instance.EquipItem(slot.item);
            InitSetInfo();
            slot.SetSlot(slot.item);
        }
        else
        {
            if (gm.ID != slot.item.ID)
            {
                UIManager.Instance.SystemMessage("먼저 착용하고 있는 장비를 해제 하세요");
                return;
            }

            ItemDataHandler.Instance.UnEquipItem(slot.item);
            InitSetInfo();
            slot.SetSlot(slot.item);
        }
    }

    public void OnEnchantItem()
    {
        ItemDataHandler.Instance.TryEnchantItem(slot.item);
        InitSetInfo();
    }
}