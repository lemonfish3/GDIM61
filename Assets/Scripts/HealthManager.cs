using UnityEngine;

public class GameManagerHealthChecker : MonoBehaviour
{
    private PlayerHealth[] players;
    public GameManager gameManager;

    private void Start()
    {
        players = FindObjectsOfType<PlayerHealth>();
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }
    }

    private void Update()
    {
        int deadCount = 0;

        foreach (PlayerHealth player in players)
        {
            if (player.currentHealth <= 0)
            {
                deadCount++;
            }
        }

        if (deadCount == players.Length)
        {
            Debug.Log("All characters dead. Game Over.");
            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
