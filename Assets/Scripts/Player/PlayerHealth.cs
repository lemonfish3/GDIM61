using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool shieldActive = false;

    public float maxHealth = 100;
    public float currentHealth;

    public TextMeshProUGUI healthText;
    public float damageInterval = 1f;
    public float damagePerSecond = 10f;
    public float damageRadius = 1f;

    private float timer = 0f;
    private GameObject[] enemies;

    public GameManager gameManager;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        // Assign UI text if not set
        if (healthText == null)
        {
            GameObject uiText = GameObject.Find("HP");
            if (uiText != null)
            {
                Debug.Log("find ui");
                healthText = uiText.GetComponent<TextMeshProUGUI>();
            }
        }

        // Assign GameManager if not set
        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }

        // Assign HealthBar if not set
        if (healthBar == null)
        {
            healthBar = FindFirstObjectByType<HealthBar>();
        }

        UpadateHealthUI();
    }

    void Update()
    {
        if (transform != CharacrerSwitch.ActivePlayer) return;

        timer += Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist < damageRadius && timer >= damageInterval)
                {
                    TakeDamage(damagePerSecond);
                    timer = 0f;
                }
            }
        }
    }

    void UpadateHealthUI()
    {
        if (healthText != null)
        {
            Debug.Log("HP updating..");
            healthText.text = $"HP: {Mathf.Ceil(currentHealth)}";
        }
    }

    public void TakeDamage(float damage)
    {
        if (shieldActive)
        {
            Debug.Log("shield active");
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpadateHealthUI();

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            if (healthBar != null)
            {
                healthBar.UpdateHealth(0f, maxHealth); // Force exact zero
            }

            Debug.Log("player died");
            gameManager.GameOver();
        }
    }

    public void ForceUpdateUI()
    {
        UpadateHealthUI();
    }
}
