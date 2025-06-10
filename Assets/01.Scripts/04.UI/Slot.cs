using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;

    public Image icon;
    public GameObject equipmentMark;
    public GameObject stackAmountMark;

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
            if (EI.isEquipped)
            {
                equipmentMark.SetActive(true);
            }
        }

        if (item.itemData is ConsumableItem || item.itemData is ResourceItem)
        {
            stackAmountMark.SetActive(true);
        }
    }

    public void ONDestroySlot()
    {
        if (UIManager.Instance.inventory.slots.Count <= 9)
        {
            ResetSlot();
            return;
        }

        if (item.itemData is EquipmentItem EI)
        {
            if (EI.isEquipped)
            {
                Debug.Log("아이템 장착을 해제하쇼");
                return;
            }
        }


        UIManager.Instance.inventory.slots.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public void ResetSlot()
    {
        item = null;
        icon.sprite = null;
        equipmentMark.SetActive(false);
        stackAmountMark.SetActive(false);
    }
}