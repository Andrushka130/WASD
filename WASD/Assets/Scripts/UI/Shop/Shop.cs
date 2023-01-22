using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Shop : MonoBehaviour
{
   
    void Awake()
    {
        
    }

    public void OpenGame()
    {
      SceneManager.LoadSceneAsync("SampleScene");
      Time.timeScale = 1f;
    }

    private void InitializeItemShop(){

    }

    private void InitializeAttributeShop(){

    }
}
