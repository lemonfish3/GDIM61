using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;
    private EnemyAI enemyAI;
    public EnemyHealthBar healthBar;

    public UnityEvent onDeath;

    private void Start()
    {
        currentHealth = maxHealth;
        enemyAI = GetComponent<EnemyAI>();

        UpdateHealthUI();
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UnityEngine.Debug.Log("Enemy took damage: " + damage + ", now at " + currentHealth);
        UpdateHealthUI();
        if (currentHealth <= 0)
        {
            UnityEngine.Debug.Log("Enemy health hit 0, calling Die()");
            enemyAI.Die();
            onDeath?.Invoke();
        }
    }
    public void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.UpdateHealth(currentHealth, maxHealth);
        }
    }
}
