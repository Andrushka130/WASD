using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject leaderboard;
    public bool leaderboardIsNotActive;

    public void StartGame(){
        Debug.Log("Started Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ManageLeaderboard(){
       leaderboard.SetActive(leaderboardIsNotActive);
       leaderboardIsNotActive = !leaderboardIsNotActive;
    }

    public void OpenOptions(){
        SceneManager.LoadScene("Options");
    }

    public void ExitGame(){
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
