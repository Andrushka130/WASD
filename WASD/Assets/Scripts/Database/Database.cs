using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Database : MonoBehaviour
{
    private static string urlPlayerData = "http://127.0.0.1:3000/playerdata/";
    private static string urlAccount = "http://127.0.0.1:3000/account/";

    public static IEnumerator Login(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount + _playerData.PlayerTag;
        string method = "POST";
        yield return WebRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator UpdateHighscore(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlPlayerData + _playerData.PlayerTag;
        string method = "PATCH";
        yield return WebRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator CreateAccount(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount;
        string method = "POST";
        yield return WebRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator ChangeAccount(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount + _playerData.PlayerTag;
        string method = "PATCH";
        yield return WebRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator DeleteAccount(string playerTag, System.Action<string> callback = null)
    {
        string url = urlAccount + playerTag;
        string method = "DELETE";
        yield return WebRequest.Download(url, method, callback);
    }

    public static IEnumerator GetHighscore(System.Action<string> callback = null)
    {
        string url = urlPlayerData;
        string method = "GET";
        yield return WebRequest.Download(url, method, callback);
    }

    public static IEnumerator GetHighscore(string playerTag, System.Action<string> callback = null)
    {
        string url = urlPlayerData + playerTag;
        string method = "GET";
        yield return WebRequest.Download(url, method, callback);
    }

    public static IEnumerator InitTestData()
    {
        using (StreamReader r = new StreamReader("Assets/Scripts/Database/DatabaseTestData.json"))
        {
            string json = r.ReadToEnd();
            PlayerData[] testData = PlayerData.ParseAll(json).Items;

            foreach(PlayerData item in testData)
            {
                yield return CreateAccount(item, result => {Debug.Log(result);});
            }
        }
    }
}
