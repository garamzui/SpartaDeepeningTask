using System;
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
    public GameObject throwButton;
    public GameObject enchantButton;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;
    public TextMeshProUGUI itemUseableLevel;
    public TextMeshProUGUI tradable;
    public TextMeshProUGUI itemPrice;


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
        Debug.Log($"[CHECK] itemData 타입: {slot.item.itemData.GetType().Name}, 이름: {slot.item.itemData.itemDataName}");
        icon.sprite = slot.item.itemData.icon;
        itemName.text = slot.item.itemData.itemName;
        itemDescription.text = slot.item.itemData.description;

        itemUseableLevel.text = $"사용 가능 Lv : {slot.item.itemData.useAbleLevel.ToString()}";
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
            itemType.text = $" 타입 : {EI.itemType.ToString()}";
            if (EI.enchantLevel == 0)
            {
                itemValue1.text = $"공격력 : {EI.damage} ";
                itemValue2.text = $"방어력 : {EI.defense}";
            }
            else
            {
                if (EI.itemType == EquipItemType.Weapon)
                {
                    itemValue1.text = $"공격력 : {EI.damage} + <color=#00FFFF>{EI.enchantedDamage}</color>";
                    itemValue2.text = $"방어력 : {EI.defense}";
                }
                else if (EI.itemType == EquipItemType.Armor)
                {
                    itemValue1.text = $"공격력 : {EI.damage} ";
                    itemValue2.text = $"방어력 : {EI.defense}+ <color=#00FFFF>{EI.enchantedDefense}</color>";
                }
            }

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
            equipButton.gameObject.SetActive(true);
            equipButtonText.text = "사용";
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

    public void OnInfoEquipItem()
    {
        var gm = GameManager.Instance.Player.currentEquipmentWeaponData;

       
        

        if (gm == null)
        {
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
}