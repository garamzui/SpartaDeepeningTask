using UnityEngine;
using UnityEngine.UI;

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

public abstract class ItemData 
{
    public string itemName;
    public string description;
    public int useAbleLevel;
    public float price;
    public bool isTradable;
    public Sprite icon;
    public GameObject itemPrefab;
}




