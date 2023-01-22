using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
   [SerializeField]
   private Options options;
   
   public void OnPointerClick(PointerEventData eventData)
   {
      options.SwapPages(this);
   }
   

}