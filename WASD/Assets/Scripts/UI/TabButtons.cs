using UnityEngine;
using UnityEngine.EventSystems;

public class TabButtons : MonoBehaviour, IPointerClickHandler
{
   [SerializeField]
   private Options options;
   
   public void OnPointerClick(PointerEventData eventData)
   {
      options.SwapPages(this);
   }
}