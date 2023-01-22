using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    [SerializeField] private string playerTag;
    [SerializeField] private string password;
    [SerializeField] private string email;
    [SerializeField] private ulong highscore;
    [SerializeField] private bool loggedIn;

    private static string highscoreStr = "highscore";
    private static string loggedInStr = "logedIn";
    private static string playerTagStr = "playerTag";

    private static PlayerData instance = null;
    private static readonly object padlock = new object();

    private PlayerData()
    {
    }

    public string PlayerTag
  {
    get { return playerTag; }
    set { playerTag = value; }
  }

  public string Password
  {
    get { return password; }
    set { password = value; }
  }

  public string Email
  {
    get { return email; }
    set { email = value; }
  }

  public ulong Highscore
  {
    get { return highscore; }
    set { highscore = value; }
  }

  public bool LoggedIn
  {
    get { return loggedIn; }
    set { loggedIn = value; }
  }

  public static PlayerData Instance
  {
    get
    {
      lock (padlock)
      {
        if (instance == null)
        {
          instance = new PlayerData();
        }
        return instance;
      }
    }
  }

    public string Stringify() 
    {
        return JsonUtility.ToJson(this);
    }

    public static PlayerData Parse(string json)
    {
        return JsonUtility.FromJson<PlayerData>(json);
    }

    public static PlayerDataList ParseAll(string json)
    {
        return JsonUtility.FromJson<PlayerDataList>(json);
    }

    public void SaveHighscore()
    {
        PlayerPrefs.SetString(highscoreStr, PlayerData.Instance.Highscore.ToString());
        PlayerPrefs.Save();
    }

    public void SaveLoginStatus()
    {
        PlayerPrefs.SetString(loggedInStr, PlayerData.Instance.LoggedIn.ToString());
        PlayerPrefs.Save();
    }

    public void SavePlayerTag()
    {
        PlayerPrefs.SetString(playerTagStr, PlayerData.Instance.PlayerTag);
        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        if(PlayerPrefs.HasKey(playerTagStr))
        {
            PlayerData.Instance.PlayerTag = PlayerPrefs.GetString(playerTagStr);
        }
        else
        {
          PlayerData.Instance.PlayerTag = "Player";
        }
        if(PlayerPrefs.HasKey(highscoreStr))
        {
            PlayerData.Instance.Highscore = Convert.ToUInt64(PlayerPrefs.GetString(highscoreStr));
        } 
        else
        {
          PlayerData.Instance.Highscore = 0;
        }
        if(PlayerPrefs.HasKey(loggedInStr))
        {
            PlayerData.Instance.LoggedIn = Convert.ToBoolean(PlayerPrefs.GetString(loggedInStr));
        }
        else
        {
          PlayerData.Instance.LoggedIn = false;
        }

        PlayerData.Instance.Email = "";
        PlayerData.Instance.Password = "";
    }
}

[Serializable]
public class PlayerDataList
{
    public PlayerData[] Items;
}
