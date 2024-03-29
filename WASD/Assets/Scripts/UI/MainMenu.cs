using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private bool leaderboardIsNotActive;
    [SerializeField] private TextMeshProUGUI highscoreText;
    [SerializeField] private GameObject loginButton;
    [SerializeField] private GameObject deleteAccountButton;
    [SerializeField] private TMP_Text logInfo;

    private PlayerData _playerData;

     void Awake()
    {
        _playerData = PlayerData.Instance;
        highscoreText.text = _playerData.Highscore.ToString();     
    }



    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ManageLeaderboard()
    {
       leaderboard.SetActive(leaderboardIsNotActive);
       UpdateLoginText();
       loginButton.SetActive(leaderboardIsNotActive);
       deleteAccountButton.SetActive(leaderboardIsNotActive && _playerData.LoggedIn);
       leaderboardIsNotActive = !leaderboardIsNotActive;
    }

    public void OpenOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void OpenLoginScreen()
    {        
        if (_playerData.LoggedIn)
        {
           _playerData.LoggedIn = false;
           _playerData.SaveLoginStatus();
           deleteAccountButton.SetActive(false);
           UpdateLoginText();
        }
        else
        {
           SceneManager.LoadSceneAsync("LoginScreen");
        }
    }

    public async void DeleteAccount()
    {
       Database db = new Database();
       string result = await db.DeleteAccount(_playerData.PlayerTag);
       _playerData.LoggedIn = false;
       deleteAccountButton.SetActive(false);
       UpdateLoginText();
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    private void  UpdateLoginText()
    {
       if (_playerData.LoggedIn){
         logInfo.text = "LogOut";
       } else {
         logInfo.text = "LogIn";
       }
    }
}
