using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 5f;
    public float lifeTime = 2f;
    //new
    public float damage = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime); // destroy after some time to avoid clutter
    }

    private void Update()
    {
        transform.position += (Vector3)(direction.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // or other collision logic
        {
            Debug.Log("Bullet hit enemy!");
            // new: apply damage (will trigger Die() if health <= 0)
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
            

       
            //Destroy(other.gameObject);  // destroy the enemy
           // Destroy(gameObject);

            //if (EnemyCounter.Instance != null)
            //{
            //    EnemyCounter.Instance.EnemyDestroyed();
            //}
        }
    }
}
