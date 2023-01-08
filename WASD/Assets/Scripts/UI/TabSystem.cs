using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSystem : MonoBehaviour
{
    public List<GameObject> tabPages;
    
    public void SwapPages(TabButton button)
    {
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < tabPages.Count; i++ ){
            if(i == index){
                tabPages[i].SetActive(true);
            } 
            else 
            {
                tabPages[i].SetActive(false);
            }
        }
    }


}
