using System.Dynamic;
using System.Collections;
using System.Text;

public class Database
{
    private static WebRequest _webRequest = WebRequest.Instance;
    private static string urlPlayerData = "http://127.0.0.1:3000/playerdata/";
    private static string urlAccount = "http://127.0.0.1:3000/account/";
    private static Database instance = null;
    private static readonly object padlock = new object();

    private Database()
    {
    }

    public static IEnumerator Login(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount + _playerData.playerTag;
        string method = "POST";
        yield return _webRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator UpdateHighscore(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlPlayerData + _playerData.playerTag;
        string method = "PATCH";
        yield return _webRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator CreateAccount(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount;
        string method = "POST";
        yield return _webRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator ChangeAccount(PlayerData _playerData, System.Action<string> callback = null)
    {
        string url = urlAccount + _playerData.playerTag;
        string method = "PATCH";
        yield return _webRequest.Upload(_playerData.Stringify(), url, method, callback);
    }

    public static IEnumerator DeleteAccount(string playerTag, System.Action<string> callback = null)
    {
        string url = urlAccount + playerTag;
        string method = "DELETE";
        yield return _webRequest.Download(url, method, callback);
    }

    public static IEnumerator GetHighscore(System.Action<string> callback = null)
    {
        string url = urlPlayerData;
        string method = "GET";
        yield return _webRequest.Download(url, method, callback);
    }

    public static IEnumerator GetHighscore(string playerTag, System.Action<string> callback = null)
    {
        string url = urlPlayerData + playerTag;
        string method = "GET";
        yield return _webRequest.Download(url, method, callback);
    }
}
