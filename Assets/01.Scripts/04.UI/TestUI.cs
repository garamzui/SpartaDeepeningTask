using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class TestUI : MonoBehaviour
{
    public GameObject Window;
    public GameObject OpenBtn;
    public GameObject CloseBtn;
    private ItemDataHandler IDH;
    private UIManager UIM;
    public StatHandler SH;
    private ItemManager IM;

    private void Start()
    {
        IM = ItemManager.Instance;
        IDH = ItemDataHandler.Instance;
        UIM = UIManager.Instance;
    }

    public void OnClickUp()
    {
        OpenBtn.SetActive(false);
        CloseBtn.SetActive(true);
        /*Window.SetActive(true);*/

        Window.transform.DOLocalMove(Vector3.down * 390f, 0.7f).SetEase(Ease.OutCubic); //트위닝 사용해 봄
    }

    public void OnClickDown()
    {
        OpenBtn.SetActive(true);
        CloseBtn.SetActive(false);


        Window.transform.DOLocalMove(Vector3.down * 690, 0.7f)
            .SetEase(Ease.OutCubic); /*.OnComplete(() => {Window.SetActive(false); });*/
    }


    public void OnMoneyPlus()
    {
        SH.ModifyStat(StatType.Money, 100);
        Debug.Log($"{SH.GetStat(StatType.Money)} ");
        UIM.statusPreView.TextReFresh();
        UIM.status.SetStatus();
    }

    public void OnMoneyMinus()
    {
        SH.ModifyStat(StatType.Money, -100);
        Debug.Log($"{SH.GetStat(StatType.Money)} ");
        UIM.statusPreView.TextReFresh();
        UIM.status.SetStatus();
    }

    public void OnEXPPlus()
    {
        SH.ModifyStat(StatType.EXP, +10);
        Debug.Log($"{SH.GetStat(StatType.EXP)} ");
        if (SH.GetStat(StatType.EXP) >= SH.GetStat(StatType.NecessaryEXP))
        {
            SH.SetStat(StatType.EXP, 0);
            GameManager.Instance.Player.LevelUp();
            UIM.SystemMessage($"레벨 업\nLevel : {SH.GetStat(StatType.Level) }");
        }

        UIM.statusPreView.TextReFresh();
        UIM.status.SetStatus();
    }

    public void OnHPMinus()
    {
        if (SH.GetStat(StatType.Health) <= 10)
        {
            SH.SetStat(StatType.Health, 10);
            UIM.SystemMessage("이러다가 죽어욧");
            return;
        }
        
        SH.ModifyStat(StatType.Health, -10);
        Debug.Log($"{SH.GetStat(StatType.Health)} ");
        UIM.statusPreView.TextReFresh();
        UIM.status.SetStatus();
    }

    public void OnPotato()
    {
        if (!UIM.inventory.gameObject.activeInHierarchy)
        {UIM.SystemMessage("인벤토리를 열고 시도해 주세요 ");
            return;
        }

        Item potato = IM.CreateItem(ItemName.Potato);
        UIM.inventory.AddItem(potato);
    }

    public void OnHONS()
    {
        if (!UIM.inventory.gameObject.activeInHierarchy)
        {UIM.SystemMessage("인벤토리를 열고 시도해 주세요 ");
            return;
        }
        Item HONS = IM.CreateItem(ItemName.HandOfNiceSon);
        UIM.inventory.AddItem(HONS);
    }

    public void OnWarning()
    {
        UIM.SystemMessage("시스템 메세지 테스트 입니다");
    }

    public void OnSceneReload()
    {
        SceneManager.LoadScene("00.Scenes/SampleScene");
    }
}