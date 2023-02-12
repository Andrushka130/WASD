using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;

public class WebRequest
{
    protected async Task<string> AsyncDownload(string url, string method)
    {
        UnityWebRequest request = new UnityWebRequest(url, method);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            return request.error;
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            return request.downloadHandler.text;
        }
    }

    protected async Task<string> AsyncUpload(string profile, string url, string method)
    {
        UnityWebRequest request = new UnityWebRequest(url, method);
        request.SetRequestHeader("Content-Type", "application/json");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(profile);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SendWebRequest();
        while (!request.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
            return request.downloadHandler.text;
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            return request.downloadHandler.text;
        }
    }
}