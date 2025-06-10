using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Status : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI defenceText;

    public void SetStatus()
    {
        var GM = GameManager.Instance.Player.statHandler;
        nameText.text ="이름 :"+GM.statData. characterName;
        levelText.text ="레벨 : "+ GM.GetStat(StatType.Level).ToString();
        expText.text = $"경험치 : {GM.GetStat(StatType.EXP)}/{GM.GetStat(StatType.NecessaryEXP)}";
        moneyText.text = "소지금 :" +GM.GetStat(StatType.Money).ToString();
        hpText.text = $"체력 : {GM.GetStat(StatType.Health)}/{GM.GetStat(StatType.MAXHealth)}";
        damageText.text = $"공격력 :  {GM.GetStat(StatType.Damage)} <color=#00FFFF>+{GM.GetStat(StatType.EnchantedDamage)} </color>";
        defenceText.text =$"방어력 :  {GM.GetStat(StatType.Defence)} <color=#00FFFF>+ {GM.GetStat(StatType.EnchantedDefence)}</color>";
    }
}

