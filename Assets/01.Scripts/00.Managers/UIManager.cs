using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : SingleTon<UIManager>
{
    public Inventory inventory;
    public ItemInfo itemInfo;
    public MainUI mainUI;
    public SetButton setButton;
    public StatusPreView statusPreView;
    public Status status;
    public Image warningImage;
    public TextMeshProUGUI warningText;

    private void Start()
    {
        //매개변수 true넣으면 off되어있는 오브젝트도 찾아올 수 있음 
        inventory = GetComponentInChildren<Inventory>(true);
        mainUI = GetComponentInChildren<MainUI>(true);
        setButton = GetComponentInChildren<SetButton>(true);
        itemInfo = GetComponentInChildren<ItemInfo>(true);
        statusPreView = GetComponentInChildren<StatusPreView>(true);
        status = GetComponentInChildren<Status>(true);
    }

    public void WarningMassage(string text)
    {
        StartCoroutine(Warning(text));
    }

    public IEnumerator Warning(string text)
    {
        warningText.text = text;
        warningImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        warningImage.gameObject.SetActive(false);
        warningText.text = string.Empty;
    }
}