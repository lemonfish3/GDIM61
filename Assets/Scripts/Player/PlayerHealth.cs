using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public TextMeshProUGUI healthText;
    public float damageInterval = 1f;
    public float damagePerSecond = 10f;
    public float damageRadius = 1f;

    private float timer = 0f;
    private GameObject[] enemies;

    public GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        currentHealth = maxHealth;
        // Automatically find the UI Text in the scene
        if (healthText == null)
        {
            GameObject uiText = GameObject.Find("HP");
            if (uiText != null)
            {
                Debug.Log("find ui");
                healthText = uiText.GetComponent<TextMeshProUGUI>();
            }
                
        }

        if (gameManager == null)
        {
            gameManager = FindFirstObjectByType<GameManager>();
        }

        UpadateHealthUI();
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Transform current = CharacrerSwitch.ActivePlayer;
                float dist = Vector2.Distance(current.position, enemy.transform.position);
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
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpadateHealthUI();

        if (currentHealth <= 0)
        {
            Debug.Log("player died");
            gameManager.GameOver();
        }
    }
}
