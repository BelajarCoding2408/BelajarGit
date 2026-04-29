using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentGameState { get; private set; } = GameState.MainMenu;

    public void SetState(GameState newState)
    {
        CurrentGameState = newState;

        switch (CurrentGameState)
        {
            case GameState.MainMenu:
                Time.timeScale = 0;
                break;

            case GameState.Playing:
                Time.timeScale = 1;
                break;

            case GameState.Paused:
                Time.timeScale = 0;
                break;

            case GameState.GameOver:
                Time.timeScale = 0;
                break;
        }
    }

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        CurrentGameState = GameState.Playing;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        CurrentGameState = GameState.Paused;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        CurrentGameState = GameState.GameOver;
    }

    public void ResumeGame() // tambahan Tab
    {
        Time.timeScale = 1f;
        CurrentGameState = GameState.Playing;
    }

    public enum GameState // tambahan Tab
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
}