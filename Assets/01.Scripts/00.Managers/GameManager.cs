using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon <GameManager>
{
    public Player Player{ get; private set; }
    public Item Item{ get; private set; }

   
    
    protected override void Awake()
    {
        base.Awake();
        
    }

    private void Start()
    {
        Player = FindObjectOfType<Player>();
        Item = FindObjectOfType<Item>();
      
    }
}
