using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;

    public static bool gameIsOver;


    void Start()
    {
        gameIsOver = false;
        gameOverScreen.SetActive(false);
    }


    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        gameObject.GetComponent<CustomWave>().ClearEnemies();
        gameObject.GetComponent<CustomWave>().DisableWave();
        gameObject.GetComponent<CustomWave>().EnableWave();
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
