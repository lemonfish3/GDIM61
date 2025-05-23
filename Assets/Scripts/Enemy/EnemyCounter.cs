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

    public float timeLimit = 180f;
    public TextMeshProUGUI timerText;

    public string activeInScene = "level3";
    public TextMeshProUGUI enemyCountText; // UI Text to display count
    public GameObject levelCompleteScreen; // UI panel for level complete

    private float timeRemaining;
    private bool questEnded = false;
    private bool isActiveScene = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        isActiveScene = SceneManager.GetActiveScene().name == activeInScene;
        if (isActiveScene )
        {
            timeRemaining = timeLimit;
        }
        UpdateUI();
        levelCompleteScreen.SetActive(false);
    }

    private void Update()
    {
        if (!isActiveScene || questEnded) return;

        timeRemaining -= Time.deltaTime;
        UpdateTimerUI();

        if (timeRemaining <= 0f)
        {
            timeRemaining = 0f;
            EndQuest();
        }
    }

    private void EndQuest()
    {
        questEnded = true;

        // Call the GameManager's GameOver() instead
        GameManager gm = FindFirstObjectByType<GameManager>();
        gm.GameOver();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = $"Time Left: {Mathf.Ceil(timeRemaining)}s";
        }
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

    private void UpdateUI()
    {
        UpdateEnemyUI();
        UpdateTimerUI();
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
