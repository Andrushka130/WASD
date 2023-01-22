using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealthManager : MonoBehaviour
{
    private static int currentHealth;
    private PlayerAttribute _playerAttribute;

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

    private void Die() 
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}