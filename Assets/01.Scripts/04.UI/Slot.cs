using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
   
    public Item item;
    public GameObject equipmentMark;
    public GameObject stackAmountMark;

    private void Start()
    {
    }

    public void OnClickInfo()
    {  UIManager.Instance.itemInfo.slot = this;
        UIManager.Instance.itemInfo.InfoWIndowOnAndOff();
    }
    public void ONDestroySlot()
    {
        if (UIManager.Instance.inventory.slots.Count <= 9)
        {
          ResetSlot();
            return;
        }

        if (item.itemDataHandler.itemData is EquipmentItem EI)
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