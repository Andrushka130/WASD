using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class Datenbank
{
    private static string url = "http://127.0.0.1:3000/playerdata/";
    private static Datenbank instance = null;
    private static readonly object padlock = new object();

    private Datenbank()
    {
    }

    public static Datenbank Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new Datenbank();
                }
                return instance;
            }
        }
    }

    public IEnumerator DownloadOne(string id, System.Action<PlayerData> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url + id))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(null);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(PlayerData.Parse(request.downloadHandler.text));
                }
            }
        }
    }

    public IEnumerator DownloadAll(System.Action<PlayerDataList> callback = null)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if (callback != null)
                {
                    callback.Invoke(null);
                }
            }
            else
            {
                if (callback != null)
                {
                    callback.Invoke(PlayerData.ParseAll(request.downloadHandler.text));
                }
            }
        }
    }

    public IEnumerator Upload(string profile, System.Action<bool> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
                if(callback != null) 
                {
                    callback.Invoke(false);
                }
            }
            else
            {
                if(callback != null) 
                {
                    callback.Invoke(request.downloadHandler.text != "{}");
                }
            }
        }
    }
}
