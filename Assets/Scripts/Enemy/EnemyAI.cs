using System;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float speed = 2f;
    public float spawnRadius = 10f;

    private Camera cam;
    private bool canShoot = false;
    public GameObject EnemyWeaponPrefab;
    public float shootInterval = 2f;
    private float shootTimer = 0f;

    public GameObject itemDropPrefab;

    void Start()
    {
        cam = Camera.main;

        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle.normalized * spawnRadius;
        Vector2 spawnPosition = CharacrerSwitch.ActivePlayer.position + (Vector3)randomOffset;
        transform.position = spawnPosition;

        // only allow shooting in the ChallengeWorld scene
        if (SceneManager.GetActiveScene().name == "ChallengeWorld")
        {
            canShoot = true;
        }
    }

    void Update()
    {
        Transform player = CharacrerSwitch.ActivePlayer;
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        shootTimer += Time.deltaTime;
        if (canShoot && shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f;
        }
    }

    void ShootAtPlayer()
    {
        if (CharacrerSwitch.ActivePlayer == null || EnemyWeaponPrefab == null) return;

        Vector2 direction = (CharacrerSwitch.ActivePlayer.position - transform.position).normalized;
        GameObject projectile = Instantiate(EnemyWeaponPrefab, transform.position, Quaternion.identity);

        EnemyWeapon proj = projectile.GetComponent<EnemyWeapon>();
        if (proj != null)
        {
            proj.SetDirection(direction);
        }
    }

    public void Die()
    {
        UnityEngine.Debug.Log("Enemy died! Scene: " + SceneManager.GetActiveScene().name);

        if (SceneManager.GetActiveScene().name == "ChallengeWorld" && itemDropPrefab != null)
        {
            UnityEngine.Debug.Log("Dropping item!");
            Instantiate(itemDropPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            UnityEngine.Debug.Log("Did not drop item: either wrong scene or prefab is null.");
        }

        Destroy(gameObject);
    }


    bool IsVisibleOnScreen()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        return viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1;
    }
}
