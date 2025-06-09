using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemDataHandler itemDataHandler;
    
   
    
    
    void Start()
    {
        itemDataHandler = GetComponent<ItemDataHandler>();
    }
}
