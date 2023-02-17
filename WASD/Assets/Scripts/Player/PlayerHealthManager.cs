using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealthManager : MonoBehaviour
{
    private static float currentHealth;
    [SerializeField] private Image healthBar;
    private static Characters currentChar;
    private static Database _db = new Database();

    public float CurrentHealth 
    {
        get { return currentHealth; }
    }
    private void Start() {
        currentChar = CharactersManager.CurrentChar;
        currentHealth = currentChar.MaxHealthValue;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Health"))
        {
            if (currentHealth + 1 > currentChar.MaxHealthValue)
            {
                currentHealth = currentChar.MaxHealthValue;
            } 
            else 
            {
                GainHealth(1);
            }
            UpdateHealth();
            Destroy(collider.gameObject);
        }
    }

    public void UpdateHealth()
    {
        healthBar.fillAmount = currentHealth / currentChar.MaxHealthValue;
    }

    public void GainHealth(float healthGained)
    {
        currentHealth += healthGained;
        //lerpTimer = 0f;
    }

    public void DamagePlayer(float damage)
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