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
        if (Input.GetKeyDown(fireKey) && Time.time - lastShotTime >= shootCooldown)
        {
            Vector2 shootDirection = playerController.lastMoveDirection;

            Debug.Log($"Shooting Direction: {shootDirection}");
            Debug.DrawRay(firePoint.position, shootDirection * 2, Color.red, 1f);

            Shoot(shootDirection);
            lastShotTime = Time.time;
        }
    }

    private void Shoot(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = direction;
    }
}

