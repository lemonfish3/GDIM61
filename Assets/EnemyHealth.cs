using System.Diagnostics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 50f;
    private float currentHealth;
    private EnemyAI enemyAI;

    private void Start()
    {
        currentHealth = maxHealth;
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UnityEngine.Debug.Log("Enemy took damage: " + damage + ", now at " + currentHealth);

        if (currentHealth <= 0)
        {
            UnityEngine.Debug.Log("Enemy health hit 0, calling Die()");
            enemyAI.Die();
        }
    }
}
