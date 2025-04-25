using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public enum GameState { Playing, Paused, GameOver}
    public GameState currentState = GameState.Playing;
    public GameObject pauseScreen;
    public GameObject gameOver;
    public GameObject pauseButton;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == GameState.Playing)
            {
                Pause();
                pauseButton.SetActive(false);
            }
            else if (currentState == GameState.Paused)
            {
                Resume();
                pauseButton.SetActive(true);
            }

        }
    }
    
    public void Pause()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
        pauseScreen.SetActive(true);
    }

    public void Resume()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
        pauseScreen.SetActive(false);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        SceneManager.LoadScene("World 1");
    }

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOver.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public void QuitGame()
    {
        Debug.Log("Quit game.");
        Application.Quit();
    }

    public void ReturnMain()
    {
        SceneManager.LoadScene("menu");
    }
}
