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
    [SerializeField] private GameObject loginButton;
    [SerializeField] private TMP_Text logInfo;

    private PlayerData _playerData;

     void Awake()
    {
        _playerData = PlayerData.Instance;
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
       if (_playerData.LoggedIn){
         logInfo.text = "LogOut";
       } else {
         logInfo.text = "LogIn";
       }
       loginButton.SetActive(leaderboardIsNotActive);
       leaderboardIsNotActive = !leaderboardIsNotActive;
    }

    public void OpenOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void OpenLoginScreen()
    {
        SceneManager.LoadSceneAsync("LoginScreen");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    
}
