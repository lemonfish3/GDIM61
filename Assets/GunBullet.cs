using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GunBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // or other collision logic
        {
            Debug.Log("Bullet hit enemy!");
            Destroy(other.gameObject);  // destroy the enemy
            Destroy(gameObject);
        }
    }
}