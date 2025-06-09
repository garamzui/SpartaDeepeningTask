using UnityEngine;

//아이템 타입을 정의 
public enum EquipItemType
{
    Weapon,
    Armor
}

public enum ConsumableType
{
    Potion,
    Projectile,
    Trap
    
}

public enum ResourceType
{
    Normal,
    Quest
}


//메뉴에 아이템 테이터 ScriptableObject로 생성

public abstract class ItemData : ScriptableObject
{
    public string itemName;
    public string discription;
    public int useAbleLevel;
}

[CreateAssetMenu(fileName = "New EquippedItem", menuName = "ItemDatas/EquippedItemData")]
public class EquippedItem : ItemData
{
    public EquipItemType itemType;
    public float damage;
    public float defense;
    public bool isEquipped;
    public float price;
    public bool isTradable;
}

[CreateAssetMenu(fileName = "New ConsumableItem", menuName = "ItemDatas/ConsumableItemData")]
public class ConsumableItem : ItemData
{
    public ConsumableType itemType;
    public float valueAmount;
    public float stackAmount;
    public bool isConsumable;
    public bool isStackable;
    public float price;
    public bool isTradable;
}

[CreateAssetMenu(fileName = "New ResourceItem", menuName = "ItemDatas/ResourceItemData")]
public class ResourceItem : ItemData
{
    public ResourceType itemType;
    public bool isStackable;
    public float price;
    public bool isTradable;
}