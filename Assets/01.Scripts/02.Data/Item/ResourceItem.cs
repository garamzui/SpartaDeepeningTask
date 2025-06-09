using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ResourceItem", menuName = "ItemDatas/ResourceItem")]
public class ResourceItem : ItemData
{
    public ResourceType itemType;
    public float valueAmount;
    public float stackAmount;
    public bool isStackable;
    public float maxStackAmount;
    
}
