using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private GameObject loginImage;

    [SerializeField] private LoginScreen loginScreen;

    private static PlayerData _playerData;

    public void OnLoginClick()
    {
        alertText.text = "";

        if(usernameInputField.text == "")
        {
            alertText.text = "Please enter username!";
            return;
        }
        if(passwordInputField.text == "")
        {
            alertText.text = "Please enter password!";
            return;
        }

        _playerData = PlayerData.Instance;
        _playerData.PlayerTag = usernameInputField.text;
        _playerData.Password = passwordInputField.text;

        Debug.Log($"{_playerData.PlayerTag}:{_playerData.Password}");

        StartCoroutine(Database.Login(_playerData, result => {
            
            if(result != "true")
            {
                alertText.text = result;
                return;
            }
            _playerData.Password = "";
            _playerData.Email = "";
            _playerData.LoggedIn = true;
            _playerData.SavePlayerTag();
            _playerData.SaveLoginStatus();
            CheckHighscore();
            loginScreen.OpenMainMenu();
            
            //loginImage.SetActive(false);
            //logoutImage.SetActive(true);
        }));
    }

    public void OnLogoutClick()
    {
        _playerData.LoggedIn = false;
        //logoutImage.SetActive(false);
        loginImage.SetActive(true);
    }

    private void CheckHighscore()
    {
        StartCoroutine(Database.GetHighscore(_playerData.PlayerTag, result => {

            if(_playerData.Highscore < PlayerData.Parse(result).Highscore)
            {
                _playerData.Highscore = PlayerData.Parse(result).Highscore;
                _playerData.SaveHighscore();
            }
            else
            {
                StartCoroutine(Database.UpdateHighscore(_playerData, result => {
                    Debug.Log(result);
                }));
            }
        }));
    }
}
