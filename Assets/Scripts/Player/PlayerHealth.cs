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
    private GameObject shield; // child object of player

    public GameManager gameManager;
    public HealthBar healthBar;

    void Awake()
    {
        currentHealth = maxHealth;  // Set right away when the object wakes
        UpdateHealthUI();
    }
    void Start()
    {
        // moved to awake()
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

    public void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = $"HP: {Mathf.Ceil(currentHealth)}";
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float damage)
    {
        if (shieldActive)
        {
            Debug.Log("Shield active");
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    public void SheildActivate()
    {
        shieldActive = !shieldActive;

        if (shield == null)
        {
            shield = transform.Find("spr_shield_0")?.gameObject;
        }

        if (shield != null)
        {
            shield.SetActive(shieldActive);
        }
        else
        {
            Debug.LogWarning("Shield child object not found!");
        }

        Debug.Log("Shield is now " + (shieldActive ? "ACTIVE" : "INACTIVE"));
    }
    public void Die()
    {
        CharacrerSwitch.Instance.SwitchToNextAliveCharacter();
    }


}
