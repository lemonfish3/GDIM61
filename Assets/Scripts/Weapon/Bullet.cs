using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 10f;
    public float lifeTime = 2f;

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
            Destroy(other.gameObject);  // destroy the enemy
            Destroy(gameObject);

            if (EnemyCounter.Instance != null)
            {
                EnemyCounter.Instance.EnemyDestroyed();
            }
        }
    }
}
