using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
    public ItemData itemData;
    public int ID= 0;
    public bool isEquipped;
    public Item(ItemName name,int itemID)
    {
        if (DataManager.Instance.ItemsForName.TryGetValue(name, out var data))
        {
            itemData = data;
        }
        else
        {
            Debug.LogError($"[Item] '{name}'is Null");
        }

        ID = itemID;
    }


    
}
