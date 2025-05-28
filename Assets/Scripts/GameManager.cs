using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private List<string> storyScenes = new List<string> {
        "Prologue", "CutScene 1", "CutScene2", "CutScene 3", "CutScene 4"
    };
    public enum GameState { Playing, Paused, GameOver }
    public GameState currentState = GameState.Playing;
    public GameObject pauseScreen;
    public GameObject gameOver;
    public GameObject pauseButton;
    public GameObject powerBar;
    public GameObject mapPanel;
    // private int currentScene = 1;

    private List<GameObject> players = new List<GameObject>();  // List to track players

    private void Start()
    {
        Time.timeScale = 1f;
    }

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

        if (Input.GetKeyDown(KeyCode.N))
        {
            HandleStorySceneAdvance();
        }
    }

    void HandleStorySceneAdvance()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (storyScenes.Contains(currentScene))
        {
            Debug.Log("skip scene");
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextIndex = currentIndex + 1;

            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextIndex);
            }
            else
            {
                ReturnMain();
            }
        }
    }

    // Add player to the list when instantiated
    public void AddPlayer(GameObject player)
    {
        players.Add(player);
    }

    public List<GameObject> GetAllPlayers()
    {
        return players;
    }


    public void Pause()
    {
        currentState = GameState.Paused;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
        pauseScreen.SetActive(true);
        powerBar.SetActive(false);
    }

    public void Resume()
    {
        currentState = GameState.Playing;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
        pauseScreen.SetActive(false);
        powerBar.SetActive(true);
    }

    /*public void Reset()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        SceneManager.LoadScene(currentScene);
    }*/

    public void GameOver()
    {
        currentState = GameState.GameOver;
        gameOver.SetActive(true);
        powerBar.SetActive(false);
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

    // This checks if all players are dead
    public void CheckGameOver()
    {
        bool allDead = true;

        foreach (GameObject player in players)
        {
            if (player.activeSelf) // If any player is alive
            {
                allDead = false;
                break;
            }
        }

        if (allDead)
        {
            GameOver();
        }
    }


    public void LoadWorld1()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        SceneManager.LoadScene("World 1");
    }

    public void LoadWorld3()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        SceneManager.LoadScene("level3");
    }

    public void LoadChallenge()
    {
        Time.timeScale = 1f;
        currentState = GameState.Playing;
        Debug.Log("load challenge");
        SceneManager.LoadScene("ChallengeWorld");
    }

    public void LoadCut1()
    {
        SceneManager.LoadScene("CutScene 1");
    }

    public void LoadCut2()
    {
        SceneManager.LoadScene("CutScene2");
    }

    public void LoadCut3()
    {
        SceneManager.LoadScene("CutScene 3");
    }

    public void LoadCut4()
    {
        SceneManager.LoadScene("CutScene 4");
    }

    public void ToggleMap()
    {
        if (mapPanel == null) return;

        bool isActive = mapPanel.activeSelf;
        mapPanel.SetActive(!isActive);
        Time.timeScale = isActive ? 1f : 0f; // Resume if closing, pause if opening
    }
}
