using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter Instance; // Singleton so other scripts can easily call it

    public int enemiesDestroyed = 0;
    public int enemiesRequired = 10;

    public TextMeshProUGUI enemyCountText; // UI Text to display count
    public GameObject levelCompleteScreen; // UI panel for level complete

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateEnemyUI();
        levelCompleteScreen.SetActive(false);
    }

    public void EnemyDestroyed()
    {
        enemiesDestroyed++;
        UpdateEnemyUI();

        if (enemiesDestroyed >= enemiesRequired)
        {
            LevelCompleted();
        }
    }

    private void UpdateEnemyUI()
    {
        if (enemyCountText != null)
        {
            enemyCountText.text = $"Enemies Destroyed: {enemiesDestroyed}/{enemiesRequired}";
        }
    }

    private void LevelCompleted()
    {
        Time.timeScale = 0f; // Pause the game
        levelCompleteScreen.SetActive(true);
    }

    // Called by UI Button
    public void NextLevel()
    {
        Time.timeScale = 1f;
        // Example: load next scene (you can adjust as needed)
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
