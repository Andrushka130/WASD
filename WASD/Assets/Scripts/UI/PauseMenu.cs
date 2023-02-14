using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    private static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private Transform attributeTemplate;

    [SerializeField] private Transform attributeContainer;

    [SerializeField] private Transform iconTemplate;

    [SerializeField] private Transform itemsContainer;

    [SerializeField] private Transform weaponsContainer;


    private List<Transform> attributes;
    
    void Start()
    {
        pauseMenuUI.SetActive(false);
        attributes = HelperUI.FillAttributes(attributeTemplate, attributeContainer);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        HelperUI.UpdateAttributes(attributes);
        HelperUI.FilltItemIcon(iconTemplate, weaponsContainer, itemsContainer);

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void OpenOptions()
    {
        SceneManager.LoadSceneAsync("Options", LoadSceneMode.Additive);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

