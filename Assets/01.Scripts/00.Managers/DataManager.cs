using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : SingleTon<DataManager>
{
    public List<ItemData> allItems = new List<ItemData>();

    private Dictionary<ItemName, ItemData> itemsForName = new Dictionary<ItemName, ItemData>();

    public Dictionary<ItemName, ItemData> ItemsForName
    {
        get { return itemsForName; }
    }
    
    protected override void Awake()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            ItemName name = allItems[i].itemDataName;
            itemsForName.Add(name, allItems[i]);
        }
    }
}