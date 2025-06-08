using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : SingleTon<UIManager>
{
   public GameManager gm;

    protected override void Awake()
    {
        base.Awake();
        
    }
    private void Start()
    {
        gm = GameManager.Instance;
    }
    
}
