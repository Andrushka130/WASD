using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest
{

    private static WebRequest instance = null;
    private static readonly object padlock = new object();

    private WebRequest()
    {
    }

    public static WebRequest Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new WebRequest();
                }
                return instance;
            }
        }
    }

    public IEnumerator Download(string url, string method, System.Action<string> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
        {
            request.downloadHandler = new DownloadHandlerBuffer();
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
                    callback.Invoke(request.downloadHandler.text);
                }
            }
        }
    }

    public IEnumerator Upload(string profile, string url, string method, System.Action<string> callback = null)
    {
        using (UnityWebRequest request = new UnityWebRequest(url, method))
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
                    callback.Invoke(request.downloadHandler.text);
                }
            }
            else
            {
                if(callback != null) 
                {
                    callback.Invoke(request.downloadHandler.text);
                }
            }
        }
    }
}