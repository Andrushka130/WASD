using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealthManager : MonoBehaviour
{
    private static int currentHealth;
    private static PlayerAttribute _playerAttribute;
    private static Database _db = new Database();

    public int CurrentHealth 
    {
        get { return currentHealth; }
    }
    private void Start() {
        _playerAttribute = PlayerAttribute.Instance;
        currentHealth = _playerAttribute.MaxHealthValue;
    }

    public void DamagePlayer(int damage)
    {
        if((currentHealth - damage) <= 0)
        {
            Die();
            return;
        }
        currentHealth -= damage;
    }

    private async void Die() 
    {
        ulong wave = GameObject.FindWithTag("SpawnManager").GetComponent<SpawnManager>().waveCounter;
        if(PlayerData.Instance.Highscore < wave)
        {
            PlayerData.Instance.Highscore = wave;
            PlayerData.Instance.SaveHighscore();
            if(PlayerData.Instance.LoggedIn)
            {
                Debug.Log(await _db.UpdateHighscore(PlayerData.Instance));
            }
        }
        SceneManager.LoadSceneAsync("MainMenu");
    }
}