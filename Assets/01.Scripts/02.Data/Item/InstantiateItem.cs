using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 아이템 Instantiate 할때 필요한 스크립트
/// </summary>
public class InstantiateItem : MonoBehaviour
{
    public Item item;

    void InIt(Item item) // Instantiate하는 쪽에서 같이 호출
    {
        this.item = item;
    }
}
