using UnityEngine;

public class PowerUpEffect : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void ApplyEffect(string effectName)
    {
        switch(effectName)
        {
            case "SpeedBoost":
                playerController.moveSpeed *= 2f;
                break;

            case "HealAll":
                HealAllCharacters(50f);
                break;
                
            case "HealOne":
                playerHealth.currentHealth = Mathf.Min(playerHealth.maxHealth, playerHealth.currentHealth + 50);
                playerHealth.ForceUpdateUI();
                break;

            case "Shield":
                playerHealth.shieldActive = true;
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
                playerController.moveSpeed /= 2f;
                break;

            case "Shield":
                playerHealth.shieldActive = false;
                break;

                // Heal effects are instant, so nothing to remove.
        }
    }

    private void HealAllCharacters(float amount)
    {
        PowerUpEffect[] allPlayers = FindObjectsByType<PowerUpEffect>(FindObjectsSortMode.None);
        foreach (var p in allPlayers)
        {
            if (p.playerHealth != null)
            {
                p.playerHealth.currentHealth = Mathf.Min(p.playerHealth.maxHealth, p.playerHealth.currentHealth + amount);
                p.playerHealth.ForceUpdateUI();
            }
        }
    }
}
