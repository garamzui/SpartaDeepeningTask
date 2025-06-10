
using UnityEngine;


public class SetButton : MonoBehaviour
{
   public GameObject [] objToOpen;
   public GameObject [] objToClose;
  public void OnOpenWindow()
   {
       for(int i=0;i<objToOpen.Length;i++)
       {objToOpen[i].SetActive(true);}
     
       for(int i=0;i<objToClose.Length;i++)
      { objToClose[i].SetActive(false);}
   }
   
}
