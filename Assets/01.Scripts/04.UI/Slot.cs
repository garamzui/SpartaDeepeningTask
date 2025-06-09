using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image icon;
    public GameObject itemInfo;

    public void ThrowItem()
    {
        Destroy(this.gameObject);
    }

    public void OnClick()
    {
        itemInfo.SetActive(!itemInfo.activeSelf); // 다른 플래그 없이 알아서 꺼져있으면 켜주고 켜져있으면 꺼줌
    }
}