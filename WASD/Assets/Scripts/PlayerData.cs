using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string playerTag;
    public string password;
    public string email;

    public ulong highscore;

    public bool loggedIn;

    private static PlayerData instance = null;
    private static readonly object padlock = new object();

    private PlayerData()
    {
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
}

[Serializable]
public class PlayerDataList
{
    public PlayerData[] Items;
}
