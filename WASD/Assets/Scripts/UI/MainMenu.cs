using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private bool leaderboardIsNotActive;
    [SerializeField] private TextMeshProUGUI highscoreText;

     void Awake()
    {
        PlayerData _playerData = PlayerData.Instance;
        highscoreText.text = _playerData.Highscore.ToString();     
    }



    public void StartGame()
    {
        Debug.Log("Started Game");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ManageLeaderboard()
    {
       leaderboard.SetActive(leaderboardIsNotActive);
       leaderboardIsNotActive = !leaderboardIsNotActive;
    }

    public void OpenOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    
}
