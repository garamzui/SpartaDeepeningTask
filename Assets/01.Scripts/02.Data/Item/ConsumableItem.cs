using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ConsumableItem", menuName = "ItemDatas/ConsumableItem")]
public class ConsumableItem : ItemData
{
    public ConsumableType itemType;
    public float valueAmount;
    public float stackAmount;
    public bool isConsumable;
    public bool isStackable;
   public float maxStackAmount;
}
