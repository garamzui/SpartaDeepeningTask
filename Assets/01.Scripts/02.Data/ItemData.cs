using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//스탯 타입을 정의 
public enum ItemType
{
    Consumable,
    Weapon,
    Armor,
    Resource,

}
//메뉴에 스탯 테이터 ScriptableObject로 생성
[CreateAssetMenu(fileName = "New ItemStatData", menuName = "ItemStats/Item StatDatas")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public List<ItemStatEntry> itemStats;
}

[System.Serializable]
public class ItemStatEntry
{
    public StatType statType;
    public float damage;
    public float defense;
    public float amount;
    public bool isConsumable;
    public bool isEquipped;
    public bool isStackable;
}