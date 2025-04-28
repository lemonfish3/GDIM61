using UnityEngine;

public class PlayerSword : MonoBehaviour
{
    public float attackRadius = 2f;
    public KeyCode attackKey = KeyCode.Q;
    public LayerMask enemyLayer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            SwingAttack();
        }
    }

    void SwingAttack()
    {
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
        Debug.Log($"Hit {enemiesHit.Length} enemies");

        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.CompareTag("Enemy"))
            {
                Destroy(enemy.gameObject);
                Debug.Log($"Destroyed enemy: {enemy.name}");

                // Tell the counter
                if (EnemyCounter.Instance != null)
                {
                    EnemyCounter.Instance.EnemyDestroyed();
                }
            }
        }
    }

}
