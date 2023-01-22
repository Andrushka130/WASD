using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        //add here reference to Player Health

        /*if(GameObject.FindWithTag("Player").GetComponent<CharacterAttribute>().CurrentHealth <= 0)
        {
            GameOverScreen();
        }
        */
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
