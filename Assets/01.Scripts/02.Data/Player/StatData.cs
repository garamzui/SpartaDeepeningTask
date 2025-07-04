using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//스탯 타입을 정의 
public enum StatType
{
    Health,
    MAXHealth,
    EXP,
    NecessaryEXP,
    Money,
    Level,
    Damage,
    EnchantedDamage,
    Defence,
    EnchantedDefence
}
//메뉴에 스탯 테이터 ScriptableObject로 생성
[CreateAssetMenu(fileName = "New StatData", menuName = "Stats/Chracter Stats")]
public class StatData : ScriptableObject
{
    public string characterName;
    public List<StatEntry> stats;
}

[System.Serializable]
public class StatEntry
{
    public StatType statType;
    public float baseValue;
}

