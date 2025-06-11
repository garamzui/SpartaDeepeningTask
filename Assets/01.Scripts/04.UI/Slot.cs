using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;

    public Image icon;
    public GameObject equipmentMark;
    public GameObject stackAmountMark;
    public TextMeshProUGUI stackAmountText;
    void Awake()
    {
    }

    public void OnClickInfo()
    {
        if (item == null) return;

        UIManager.Instance.itemInfo.slot = this;
        UIManager.Instance.itemInfo.InfoWIndowOnAndOff();
    }

    public void SetSlot(Item item)
    {
        icon.sprite = item.itemData.icon;
        if (item.itemData is EquipmentItem EI)
        {
            if (item.isEquipped)
            {
                equipmentMark.SetActive(true);
            }
            else
            {
                equipmentMark.SetActive(false);
            }
        }

        if ( item.itemData is ResourceItem RI )
        {
            if (RI.isStackable)
            {
                stackAmountMark.SetActive(true);
                stackAmountText.text = RI.stackAmount.ToString();
            }
            else
            {
                stackAmountMark.SetActive(false);
            }
        }
        
        if (item.itemData is ConsumableItem CI)
        {
            if (CI.isConsumable)
            {
                stackAmountMark.SetActive(true);
                stackAmountText.text = CI.stackAmount.ToString();
            }
            else
            {
                stackAmountMark.SetActive(false);
            }
        }
    }

    public void ONDestroySlot()
    {
        
            /*
            if (UIManager.Instance.inventory.slots.Count <= 9)
            {
                ResetSlot();
                return;
            }
            */

            if (item.itemData is EquipmentItem EI)
            {
                if (item.isEquipped)
                {
                    Debug.Log("아이템 장착을 해제하쇼");
                    UIManager.Instance.SystemMessage("먼저 아이템 장착을 해제하세요");
                    return;
                }
            }
            UIManager.Instance.itemInfo.InfoWIndowOnAndOff();
            ResetSlot();
            UIManager.Instance.inventory.slots.Remove(this.gameObject);
            Destroy(this.gameObject);
            UIManager.Instance.inventory.slot = null;
        
    }

    public void ResetSlot()
    {
        item = null;
        icon.sprite = null;
        equipmentMark.SetActive(false);
        stackAmountMark.SetActive(false);
    }
    
}