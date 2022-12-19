using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI usernameAlertText;
    [SerializeField] private TextMeshProUGUI passwordAlertText;
    [SerializeField] private GameObject loginImage;
    

    private static PlayerData _playerData;

    public void OnLoginClick()
    {
        usernameAlertText.text = "";
        passwordAlertText.text = "";

        if(usernameInputField.text == "")
        {
            usernameAlertText.text = "Please enter username!";
            return;
        }
        if(passwordInputField.text == "")
        {
            passwordAlertText.text = "Please enter password!";
            return;
        }

        _playerData = PlayerData.Instance;
        _playerData.playerTag = usernameInputField.text;
        _playerData.password = passwordInputField.text;

        Debug.Log($"{_playerData.playerTag}:{_playerData.password}");

        StartCoroutine(Database.Login(_playerData, result => {
            
            if(result != "true")
            {
                if(result == "Account not found!")
                {
                    usernameAlertText.text = result;
                    return;
                }
                if(result == "Invalid password!")
                {
                    passwordAlertText.text = result;
                    return;
                }
            }
            loginImage.SetActive(false);
        }));
    }
}
