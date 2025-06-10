using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartImage : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button applyButton;
    public TMP_Text displayText;

    private void Start()
    {
        applyButton.onClick.AddListener(ChangeName);
    }

    void ChangeName()
    {
        string newName = inputField.text;
        if (!string.IsNullOrEmpty(newName))
        {
            displayText.text = $"이름: {newName}";
        }
    }
}