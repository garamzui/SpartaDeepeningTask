using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
private Inventory inventory;
  
public StatHandler statHandler;


    void Start()
    {
        statHandler = GetComponent<StatHandler>();
        inventory = UIManager.Instance.inventory;
    }
}
