using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject hud;
    public GameObject pauseMenu;
    public GameObject GameOverMenu;

    public static UIManager Instance;

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        hud.SetActive(true);

        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }

    public void PauseGame()
    {
        mainMenu.SetActive(false);
        GameManager.Instance.SetState(GameManager.GameState.Paused);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        GameManager.Instance.SetState(GameManager.GameState.Playing);
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(true);
        GameManager.Instance.SetState(GameManager.GameState.GameOver);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}