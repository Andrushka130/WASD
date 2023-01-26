using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tabPages;
    
    public void SwapPages(TabButtons button)
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

    public void LeaveOptions()
    {
        SceneManager.UnloadSceneAsync("Options");
    }


}
