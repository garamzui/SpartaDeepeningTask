using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();//받은 아이템 인스턴스 데이터 저장 리스트
    public List<GameObject> slots = new List<GameObject>();//슬롯 리스트
    public GameObject itemSlotPrefab;//슬롯 프리팹
    public GameObject content; //슬롯 생성되는 스크롤 뷰의 콘텐트 오브젝트

    public GameObject slot;

    private void Awake()
    {
        for (int i = 0; i < 9; i++)//초기에 9개 빈 슬롯 기본 생성
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
            slots.Add(newSlot);
        }
    }

   

    public void AddItem(Item item)
    {
        items.Add(item);

        for (int i = 0; i < slots.Count; i++)
        {
            Slot slotComponent = slots[i].GetComponent<Slot>();


            if (slotComponent.item == null)
            {
                slotComponent.item = item;
                slotComponent.SetSlot(item);
                return;
            }
        }
            GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
            slots.Add(newSlot);
            newSlot.GetComponent<Slot>().item = item;
            newSlot.GetComponent<Slot>().SetSlot(item);

    }

    public void FindOpenSlot()
    {
        
         for(int i=0;i<slots.Count;i++)
        {
            if (slots[i].GetComponent<Slot>().item.ID == UIManager.Instance.itemInfo.slot.item.ID)
            {
                slot = slots[i];
                return;  
            }
          


        }
        Debug.Log (slot.GetComponent<Slot>().item.ID);
    }
   
    public void RemoveItem()
    {
        FindOpenSlot();
        
        slot.GetComponent<Slot>().ONDestroySlot();
        
        if (slots.Count < 9)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
            slots.Add(newSlot);
        }
        /*slots.Sort((a, b) => a.GetComponent<Slot>().item.ID.CompareTo(b.GetComponent<Slot>().item.ID)); */
    }


}