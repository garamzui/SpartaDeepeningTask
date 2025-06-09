using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : SingleTon<UIManager>
{
    public StatusPreView status;
    public Inventory inventory;
    public ItemInfo itemInfo;
    public MainUI mainUI;
    public SetButton setButton;

    private void Start()
    {
        status = GetComponentInChildren<StatusPreView>(true); //매개변수 true넣으면 off되어있는 오브젝트도 찾아올 수 있음 
        inventory = GetComponentInChildren<Inventory>(true);
        mainUI = GetComponentInChildren<MainUI>(true);
        setButton = GetComponentInChildren<SetButton>(true);
        itemInfo = GetComponentInChildren<ItemInfo>(true);
    }
}