using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreen : MonoBehaviour
{
    [SerializeField] private GameObject containerLogin;
    [SerializeField] private GameObject containerCreateAccount;

    public void OpenMainMenu()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowLogin(){
        containerCreateAccount.SetActive(false);
        containerLogin.SetActive(true);
    }

    public void ShowCreateAccount(){
        containerLogin.SetActive(false);
        containerCreateAccount.SetActive(true);
        
    }
}

