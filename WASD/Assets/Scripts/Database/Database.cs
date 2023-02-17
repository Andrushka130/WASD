using System.Threading.Tasks;

public class Database : WebRequest
{
    private static Database db = new Database();

    public async Task<string> Login(PlayerData _playerData)
    {
        string url = URL.UrlAccount + _playerData.PlayerTag;
        string method = HttpMethods.Post;
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> UpdateHighscore(PlayerData _playerData)
    {
        string url = URL.UrlPlayerData + _playerData.PlayerTag;
        string method = HttpMethods.Patch;
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> CreateAccount(PlayerData _playerData)
    {
        string url = URL.UrlAccount;
        string method = HttpMethods.Post;
        return await db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public Task<string> ChangeAccount(PlayerData _playerData, string currentPlayerTag)
    {
        string url = URL.UrlAccount + currentPlayerTag;
        string method = HttpMethods.Patch;
        return db.AsyncUpload(_playerData.Stringify(), url, method);
    }

    public async Task<string> DeleteAccount(string playerTag)
    {
        string url = URL.UrlAccount + playerTag;
        string method = HttpMethods.Delete;
        return await db.AsyncDownload(url, method);
    }

    public async Task<PlayerData[]> GetHighscore()
    {
        string url = URL.UrlPlayerData;
        string method = HttpMethods.Get;
        return PlayerData.ParseAll(await db.AsyncDownload(url, method)).Items;
    }

    public async Task<PlayerData> GetHighscore(string playerTag)
    {
        string url = URL.UrlPlayerData + playerTag;
        string method = HttpMethods.Get;
        return PlayerData.Parse(await db.AsyncDownload(url, method));
    }
}
