using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateAccount : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private TMP_InputField emailInputField;
    [SerializeField] private TMP_InputField passwordInputField;
    [SerializeField] private TextMeshProUGUI alertText;
   
    [SerializeField] private LoginScreen loginScreen;
  
    

    private PlayerData _playerData;

    public void OnCreateAccountClick()
    {
        alertText.text = "";

        if(usernameInputField.text == "")
        {
            alertText.text = "Please enter username!";
            return;
        }
        if(emailInputField.text == "")
        {
            alertText.text = "Please enter email!";
            return;
        }
        if(passwordInputField.text == "")
        {
            alertText.text = "Please enter password!";
            return;
        }

        _playerData = PlayerData.Instance;
        _playerData.PlayerTag = usernameInputField.text;
        _playerData.Email = emailInputField.text;
        _playerData.Password = passwordInputField.text;


        StartCoroutine(Database.CreateAccount(_playerData, result => {
            if(result != _playerData.PlayerTag + " inserted ...")
            {
                alertText.text = result;
                return; 
            }

            _playerData.Password = "";
            _playerData.Email = "";
            _playerData.LoggedIn = true;
            _playerData.SavePlayerTag();
            _playerData.SaveLoginStatus();
            loginScreen.OpenMainMenu();
            
        }));
    }
}
