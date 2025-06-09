using UnityEngine;
using TMPro;

public class StatusPreView : MonoBehaviour
{
    public StatHandler statHandler;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI moneyText;

    private void Start()
    {
        Invoke("InitBaseStatus", 0.2f);
    }

    private void InitBaseStatus()
    {
        if (statHandler == null)
        {
            statHandler = GameManager.Instance.Player.statHandler;
        }

        TextReFresh();
    }

    public void TextReFresh()
    {
        nameText.text = statHandler.statData.characterName;
        levelText.text = statHandler.GetStat(StatType.Level).ToString();
        expText.text = statHandler.GetStat(StatType.EXP).ToString();
        moneyText.text = statHandler.GetStat(StatType.Money).ToString();
    }
}