using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealth playerHealth;

    private GameManager gameManager;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();

        gameManager = FindFirstObjectByType<GameManager>(); // Cache reference
    }


    public void ApplyEffect(string effectName)
    {
        switch (effectName)
        {
            case "SpeedBoost":
                if (playerController != null)
                    playerController.moveSpeed *= 2f;
                break;

            case "HealAll":
                HealAllCharacters(50f);
                break;

            case "HealOne":
                if (playerHealth != null)
                {
                    playerHealth.currentHealth = Mathf.Min(playerHealth.maxHealth, playerHealth.currentHealth + 50);
                    playerHealth.UpdateHealthUI();
                }
                break;

            case "Shield":
                if (playerHealth != null)
                    playerHealth.SheildActivate();
                break;

            default:
                Debug.LogWarning($"Unknown power-up effect: {effectName}");
                break;
        }
    }

    public void RemoveEffect(string effectName)
    {
        switch (effectName)
        {
            case "SpeedBoost":
                if (playerController != null)
                    playerController.moveSpeed /= 2f;
                break;

            case "Shield":
                if (playerHealth != null)
                    playerHealth.SheildActivate();
                break;

                // Heal effects are instant; no removal needed.
        }
    }

    private void HealAllCharacters(float amount)
    {
        foreach (GameObject player in gameManager.GetAllPlayers())
        {
            if (player != null)
            {
                PlayerHealth health = player.GetComponent<PlayerHealth>();
                if (health != null && health.currentHealth > 0)
                {
                    health.currentHealth = Mathf.Min(health.maxHealth, health.currentHealth + amount);
                    health.UpdateHealthUI();
                }
            }
        }
    }

}
