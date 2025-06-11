using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class StatusPreView : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public Image expBar;
    public TextMeshProUGUI hpText;
    public Image hpBar;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        Invoke("TextReFresh", 0.2f);
    }


    public void TextReFresh()
    {
        var GM = GameManager.Instance.Player.statHandler;
        nameText.text = GM.statData.characterName;
        levelText.text = GM.GetStat(StatType.Level).ToString();
        expText.text = $"{GM.GetStat(StatType.EXP)} / {GM.GetStat(StatType.NecessaryEXP)}";
        expBar.fillAmount = GM.GetStat(StatType.NecessaryEXP) > 0f
            ? GM.GetStat(StatType.EXP) / GM.GetStat(StatType.NecessaryEXP)
            : 0f;
        hpText.text = $"{GM.GetStat(StatType.Health)} / {GM.GetStat(StatType.MAXHealth)}";
        hpBar.fillAmount = GM.GetStat(StatType.Health) > 0f
            ? GM.GetStat(StatType.Health) / GM.GetStat(StatType.MAXHealth)
            : 0f;
        
        moneyText.text = GM.GetStat(StatType.Money).ToString();
    }
}