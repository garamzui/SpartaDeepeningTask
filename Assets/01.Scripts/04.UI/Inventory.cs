using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject itemSlotPrefab;
    public GameObject content;
[Button]
    void GetItem()
    {
        Instantiate(itemSlotPrefab, content.transform);
    }

    void ThrowItem()
    {
    }
}
