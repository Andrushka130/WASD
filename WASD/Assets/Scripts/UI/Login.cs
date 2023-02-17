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

    private static Database db = new Database();
    private static PlayerData _playerData;

    public async void  OnLoginClick()
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

        string result = await db.Login(_playerData);
            
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
    }


    private async void CheckHighscore()
    {
        PlayerData result = await db.GetHighscore(_playerData.PlayerTag);

        if(_playerData.Highscore < result.Highscore)
        {
            _playerData.Highscore = result.Highscore;
            _playerData.SaveHighscore();
        }
        else
        {
            string result2 = await db.UpdateHighscore(_playerData);
            Debug.Log(result2);
        }
    }
}
