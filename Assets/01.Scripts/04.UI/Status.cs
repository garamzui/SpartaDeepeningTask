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

    void SetStatus()
    {
        nameText.text = GameManager.Instance.Player.statHandler.statData.characterName;
        levelText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.Level).ToString();
        expText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.EXP).ToString();
        moneyText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.Money).ToString();
        hpText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.Health).ToString();
        damageText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.Damage).ToString();
        defenceText.text = GameManager.Instance.Player.statHandler.GetStat(StatType.Defence).ToString();
    }
}