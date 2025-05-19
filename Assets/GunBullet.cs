using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GunBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(50f);
                Debug.Log($"Damaged enemy: {enemy.name}");
            }
        }
    }
}