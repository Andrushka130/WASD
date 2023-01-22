using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void OpenMainMenu()
    {
        
        SceneManager.LoadSceneAsync("MainMenu");
        
    }
}
