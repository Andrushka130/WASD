using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerClickHandler
{
   public TabSystem tabSystem;
   
   public void OnPointerClick(PointerEventData eventData){
    
    tabSystem.SwapPages(this);
    
   }
}