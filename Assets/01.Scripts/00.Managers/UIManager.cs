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
     public Image systemMessageImage;
     public TextMeshProUGUI systemText;
     private Coroutine systemMessageRoutine;
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

    public void SystemMessage(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return; 
        
        if (systemMessageRoutine != null)
        {
            StopCoroutine(systemMessageRoutine);
        }

        systemMessageRoutine = StartCoroutine(SystemText(text));
    }

    private IEnumerator SystemText(string text)
    {
        systemText.text = text;
        systemMessageImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        systemMessageImage.gameObject.SetActive(false);
        systemText.text = string.Empty;

        systemMessageRoutine = null; 
    }
}