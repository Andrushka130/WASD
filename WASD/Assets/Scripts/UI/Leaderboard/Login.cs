using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
    [SerializeField] private GameObject loginImage;
    

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
        _playerData.playerTag = usernameInputField.text;
        _playerData.password = passwordInputField.text;

        Debug.Log($"{_playerData.playerTag}:{_playerData.password}");

        StartCoroutine(Database.Login(_playerData, result => {
            
            if(result != "true")
            {
                alertText.text = result;
                return;
            }
            loginImage.SetActive(false);
        }));
    }
}
