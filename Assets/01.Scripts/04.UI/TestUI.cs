using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class TestUI : MonoBehaviour
{
    public GameObject Window;
    public GameObject OpenBtn;
    public GameObject CloseBtn;

    public void OnClickUp()
    {   
        OpenBtn.SetActive(false);
       CloseBtn.SetActive(true);
       /*Window.SetActive(true);*/
       
        Window.transform.DOLocalMove(Vector3.down*390f, 0.7f).SetEase(Ease.OutCubic);//트위닝 사용해 봄
    
    }
public void OnClickDown()
    {
        OpenBtn.SetActive(true);
        CloseBtn.SetActive(false);
        
        
        Window.transform.DOLocalMove(Vector3.down*690, 0.7f)
            .SetEase(Ease.OutCubic); /*.OnComplete(() => {Window.SetActive(false); });*/
     

    }
    

    public void OnMoneyPlus()
    {
    }

    public void OnMoneyMinus()
    {
    }

    public void OnEXPPlus()
    {
    }

    public void OnPotato()
    {
        Item potato = ItemManager.Instance.CreateItem(ItemName.Potato);
        UIManager.Instance.inventory.AddItem(potato);
    }

    public void OnHONS()
    {
        Item HONS = ItemManager.Instance.CreateItem(ItemName.HandOfNiceSon);
        UIManager.Instance.inventory.AddItem(HONS);
    }
}