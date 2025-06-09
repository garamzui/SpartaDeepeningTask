using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    public GameObject itemPrefab;
    public GameObject itemSlotPrefab;

    public GameObject content;


    private void Awake()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
            slots.Add(newSlot);
        }
    }


    void GetItem(GameObject itemPrefab)
    {
        Item newItem = Instantiate(itemPrefab).GetComponent<Item>();
        items.Add(newItem);
       
        for (int i = 0; i < slots.Count; i++)
        {
            Slot slotComponent = slots[i].GetComponent<Slot>();

           
            if (slotComponent.icon.sprite == null)
            {
                slotComponent.icon.sprite = newItem.itemDataHandler.itemData.icon;
                return;
            }
        }
            GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
            slots.Add(newSlot);
            newSlot.GetComponent<Slot>().icon.sprite = newItem.itemDataHandler.itemData.icon;
      
    }

    
}