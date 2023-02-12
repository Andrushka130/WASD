using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    private void Awake() {
        PlayerData.Instance.LoadPlayerData();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
