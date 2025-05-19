using UnityEngine;

public class PlayerShooter : MonoBehaviour
{   
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shootCooldown = 0.5f;
    public KeyCode fireKey = KeyCode.Q;

    private float lastShotTime;
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();

        if (firePoint == null)
        {
            firePoint = transform.Find("FirePoint");
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(fireKey) || Input.GetMouseButtonDown(0)) && Time.time - lastShotTime >= shootCooldown)
        {
            Transform closestEnemy = FindClosestEnemy();
            if (closestEnemy != null)
            {
                Vector2 shootDirection = (closestEnemy.position - firePoint.position).normalized;

                Debug.Log($"Shooting towards: {closestEnemy.name} at {closestEnemy.position}");
                Debug.DrawRay(firePoint.position, shootDirection * 2, Color.red, 1f);

                Shoot(shootDirection);
                lastShotTime = Time.time;
            }
            else
            {
                Vector2 shootDirection = playerController.lastMoveDirection;

                Debug.Log($"Shooting Direction: {shootDirection}");
                Debug.DrawRay(firePoint.position, shootDirection * 2, Color.red, 1f);

                Shoot(shootDirection);
                lastShotTime = Time.time;
            }
        }
    }

    private void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = direction;
    }

    private Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float minDistance = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(currentPosition, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy.transform;
            }
        }

        return closest;
    }
}

