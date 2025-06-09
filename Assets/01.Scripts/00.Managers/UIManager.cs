using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : SingleTon<UIManager>
{
  public StatusPreView status;

  
    private void Start()
    {
     status = GetComponentInChildren<StatusPreView>(true);//매개변수 true넣으면 off되어있는 오브젝트도 찾아올 수 있음 
    }
    
}
