using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealthManager : MonoBehaviour
{
    private static float currentHealth;
    [SerializeField] private Image healthBar;
    private static PlayerAttribute _playerAttribute;
    private static Database _db = new Database();

    public float CurrentHealth 
    {
        get { return currentHealth; }
    }
    private void Start() {
        _playerAttribute = PlayerAttribute.Instance;
        currentHealth = _playerAttribute.MaxHealthValue;
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / _playerAttribute.MaxHealthValue;
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