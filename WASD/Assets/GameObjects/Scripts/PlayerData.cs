using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string playerTag;
    public ulong highscore;

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
