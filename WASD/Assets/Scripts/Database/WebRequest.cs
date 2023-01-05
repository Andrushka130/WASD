using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest
{
    public static IEnumerator Download(string url, string method, System.Action<string> callback = null)
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

    public static IEnumerator Upload(string profile, string url, string method, System.Action<string> callback = null)
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