using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EquipmentItem", menuName = "EquipmentItem/EquipmentItem")]
public class EquipmentItem : ItemData
{
    public EquipItemType itemType;
   
    public float damage;
    public float defense;
    public float enchantPotencial ; 
    
}
