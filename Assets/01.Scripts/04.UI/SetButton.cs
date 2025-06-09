using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButton : MonoBehaviour
{
   public GameObject objToOpen;
   public GameObject objToClose;
  public void OnOpenWindow()
   {
      objToOpen.gameObject.SetActive(true);
      objToClose.gameObject.SetActive(false);
   }
   
}
