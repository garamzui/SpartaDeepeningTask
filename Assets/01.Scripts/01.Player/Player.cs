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

    void Start()
    {
        statHandler = GetComponent<StatHandler>();
        inventory = UIManager.Instance.inventory;
      
    }
}
