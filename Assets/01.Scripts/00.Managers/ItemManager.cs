using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : SingleTon<ItemManager>
{
    
    private List<Item> allItems = new List<Item>(); //생성된 모든 아이템 인스턴스를 담아두는 리스트 
    

    private  int itemID = 0;//아이디 부여해서 구분 해보기 종류 상관 없이 만들어진 순서대로 숫자 부여

    public Item CreateItem(ItemName name)
    {
        int ID = itemID++;
        Item item = new Item(name,ID);
        allItems.Add(item);
       
        return item;
    }

    protected override void Awake()
    {
        base.Awake();
        
    }
    
    
    
}
