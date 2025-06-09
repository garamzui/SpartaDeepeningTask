using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIRaycastExample : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster raycaster;
    [SerializeField] private EventSystem eventSystem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 좌클릭
        {
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            if (results.Count > 0)
            {
                Debug.Log("가장 먼저 닿은 UI 오브젝트: " + results[0].gameObject.name);
            }
            else
            {
                Debug.Log("UI에 닿은 오브젝트 없음");
            }
        }
    }
}