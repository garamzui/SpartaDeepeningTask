using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
private Inventory inventory;
  
public StatHandler statHandler;
public GameObject weaponPivot;
public GameObject currentEquipmentWeapon;
public GameObject currentEquipmentArmor;
public Item currentEquipmentWeaponData;
public Item currentEquipmentArmorData;
    void Start()
    {
        statHandler = GetComponent<StatHandler>();
        inventory = UIManager.Instance.inventory;
      
    }

    public void LevelUp()
    {
     statHandler.ModifyStat(StatType.Level,1f);
     statHandler.ModifyStat(StatType.MAXHealth,10f);
     statHandler.ModifyStat(StatType.NecessaryEXP,10f); 
     statHandler.ModifyStat(StatType.Damage,5f);
    }


}
