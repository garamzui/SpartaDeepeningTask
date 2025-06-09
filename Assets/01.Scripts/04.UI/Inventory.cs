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

    
    [Button]

    void GetItem(GameObject itemPrefab)
    {
        
        Item newItem = Instantiate(itemPrefab).GetComponent<Item>();
        items.Add(newItem);
        GameObject newSlot = Instantiate(itemSlotPrefab, content.transform);
        slots.Add(newSlot);
        Slot slotComponent = newSlot.GetComponent<Slot>();

        slotComponent.icon.sprite = newItem.itemDataHandler.itemData.icon;
        
    }

    void ThrowItem()
    {
        /*UIManager.In*/
    }
}