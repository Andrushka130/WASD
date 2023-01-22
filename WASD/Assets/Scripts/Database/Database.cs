using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Threading.Tasks;

public class Database : WebRequest
{
    private static string urlPlayerData = "http://127.0.0.1:3000/playerdata/";
    private static string urlAccount = "http://127.0.0.1:3000/account/";
    private static Database db = new Database();

    public async Task<string> Login(PlayerData _playerData)
    {
        string url = urlAccount + _playerData.PlayerTag;
        string method = "POST";
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> UpdateHighscore(PlayerData _playerData)
    {
        string url = urlPlayerData + _playerData.PlayerTag;
        string method = "PATCH";
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> CreateAccount(PlayerData _playerData)
    {
        string url = urlAccount;
        string method = "POST";
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public Task<string> ChangeAccount(PlayerData _playerData)
    {
        string url = urlAccount + _playerData.PlayerTag;
        string method = "PATCH";
        return db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> DeleteAccount(string playerTag)
    {
        string url = urlAccount + playerTag;
        string method = "DELETE";
        return await db.AsyncDownload(url, method);
    }

    public async Task<PlayerData[]> GetHighscore()
    {
        string url = urlPlayerData;
        string method = "GET";
        return PlayerData.ParseAll(await db.AsyncDownload(url, method)).Items;
    }

    public async Task<PlayerData> GetHighscore(string playerTag)
    {
        string url = urlPlayerData + playerTag;
        string method = "GET";
        return PlayerData.Parse(await db.AsyncDownload(url, method));
    }

    public async Task<string> InitTestData()
    {
        try
        {
            StreamReader r = new StreamReader("Assets/Scripts/Database/DatabaseTestData.json");
        
            string json = r.ReadToEnd();
            PlayerData[] testData = PlayerData.ParseAll(json).Items;

            foreach(PlayerData item in testData)
            {
                return await CreateAccount(item);
            }
        } 
        catch (FileNotFoundException e) 
        {
            Debug.Log(e.Message);
            return e.Message;
        } 
        return "Something went wrong!: InitTestData()";
    }
}
