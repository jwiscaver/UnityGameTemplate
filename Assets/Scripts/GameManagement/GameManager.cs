using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}

public class GameManager : Singleton<GameManager>
{
    #region GameManager Settings

    [Header("GameManager Settings")]
    [SerializeField]
    private GameState gameState = GameState.MainMenu;

    public GameState CurrentGameState
    {
        get { return gameState; }
    }

    #endregion

    #region Audio Settings

    [Header("Audio Settings")]
    [SerializeField]
    private AudioSource backgroundMusic;

    #endregion

    #region Player Settings

    [Header("Player Settings")]
    [SerializeField] private int playerScore = 0;
    [SerializeField] private int playerHealth = 100;
    [SerializeField] private int playerLives = 3;


    public int PlayerScore
    {
        get { return playerScore; }
    }

    public int PlayerHealth
    {
        get { return playerHealth; }
    }

    public int PlayerLives
    {
        get { return playerLives; }
    }

    #endregion

    #region Initialization

    private void Start()
    {
        Debug.Log("GameManager is ready!");

        // Example initialization code
        // You may want to assign the initial background music in the Inspector.
        // PlayMainMenuMusic();
    }

    #endregion

    #region Audio Management

    public void PlayBackgroundMusic(AudioClip music)
    {
        backgroundMusic.clip = music;
        backgroundMusic.Play();
    }

    public void PauseAudio()
    {
        backgroundMusic.Pause();
        // Add code to pause other audio sources if necessary
    }

    public void StopAudio()
    {
        backgroundMusic.Stop();
        // Add code to stop other audio sources if necessary
    }

    #endregion

    #region Game State Control

    public void SetGameState(GameState newState)
    {
        if (newState == gameState)
            return;

        GameState previousState = gameState;
        gameState = newState;

        // Handle state-specific behavior
        switch (newState)
        {
            case GameState.MainMenu:
                OnMainMenuState(previousState);
                break;

            case GameState.Playing:
                OnPlayingState(previousState);
                break;

            case GameState.Paused:
                OnPausedState(previousState);
                break;

            case GameState.GameOver:
                OnGameOverState(previousState);
                break;
        }
    }

    private void OnMainMenuState(GameState previousState)
    {
        PlayMainMenuMusic();
    }

    private void OnPlayingState(GameState previousState)
    {
        PlayGameMusic();
    }

    private void OnPausedState(GameState previousState)
    {
        PauseAudio();
        Time.timeScale = 0f; // Pause the game time
    }

    private void OnGameOverState(GameState previousState)
    {
        StopAudio();
        Time.timeScale = 1f; // Resume the game time

        // Handle game over screen, high scores, etc.
    }

    #endregion

    #region Player Management

    public void IncreaseScore(int amount)
    {
        playerScore += amount;
    }

    public void DecreaseLives()
    {
        playerLives--;

        if (playerLives <= 0)
        {
            SetGameState(GameState.GameOver);
        }
    }


    public void DecreaseHealth(int healthDecrease)
    {
        playerHealth -= healthDecrease;

        if (playerHealth <= 0)
        {
            // TO do: 
            SetGameState(GameState.GameOver);
        }
    }

    public void IncreaseHealth(int healthIncrease)
    {
        playerHealth += healthIncrease;

        if (playerHealth <= 0)
        {
            // TO do: 
            SetGameState(GameState.GameOver);
        }
    }

    public void RestartGame()
    {
        playerScore = 0;
        playerLives = 3;
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with your main menu scene name or index
    }

    #endregion

    #region Audio-Specific Methods

    private void PlayMainMenuMusic()
    {
        // Play your main menu music here
    }

    private void PlayGameMusic()
    {
        // Play your in-game music here
    }

    #endregion
}
