using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public  void OnMoneyPlus()
    {
    }

    public  void OnMoneyMinus()
    {
    }
    
    public  void OnEXPPlus()
    {
    }

   public void OnPotato()
    {
       Item potato = ItemManager.Instance.CreateItem(ItemName.Potato);
       UIManager.Instance.inventory.GetItem(potato);
    }

    public void OnHONS()
    {
        Item HONS = ItemManager.Instance.CreateItem(ItemName.HandOfNiceSon);
        UIManager.Instance.inventory.GetItem(HONS);
    }
}
