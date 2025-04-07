using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public enum GameState { Playing, Paused}
    public GameState currentState = GameState.Playing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            TogglePause();
        }
    }
    
    public void TogglePause()
    {
        if (currentState == GameState.Playing)
        {
            currentState = GameState.Paused;
            Time.timeScale = 0f;
            Debug.Log("Game Paused");
        }
        else if (currentState == GameState.Paused)
        {
            currentState = GameState.Playing;
            Time.timeScale = 1f;
            Debug.Log("Game Resumed");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit game.");
        Application.Quit();
    }
}
