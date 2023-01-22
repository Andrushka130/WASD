using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void OpenLogin()
    {
        
        SceneManager.LoadSceneAsync("MainMenu");
        
    }
}
