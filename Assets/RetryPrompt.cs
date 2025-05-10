using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryPrompt : MonoBehaviour
{
    public GameObject retryPanel;

    public void ShowRetry()
    {
        retryPanel.SetActive(true);
    }

    public void RetryBattle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}