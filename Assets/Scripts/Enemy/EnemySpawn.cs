using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public CharacrerSwitch characrerSwitch;
    public int maxEnemies = 3;
    public int totalEnemiesSpawn = 10;
    public float spawnInterval = 2f;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private float timer = 0f;

    private bool playerInside = false;
    private int enemiesSpawned = 0;

    // Update is called once per frame
    void Update()
    {
        if (!playerInside) return;
        timer += Time.deltaTime;
        activeEnemies.RemoveAll(enemy =>  enemy == null); // destroy null entries

        if (activeEnemies.Count < maxEnemies && timer >= spawnInterval && enemiesSpawned <= totalEnemiesSpawn)
        {
            SpawnEnemy();
            enemiesSpawned++;
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
        activeEnemies.Add(newEnemy);
        Debug.Log("new enemy");
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomOffset = Random.insideUnitCircle * 3f;
        Debug.Log("Get enemy position");
        return CharacrerSwitch.ActivePlayer.transform.position + (Vector3)randomOffset;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered spawn zone");
        }
    }

   /* private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is still inside trigger zone");
        }
    }*/


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            Debug.Log("player left spawn zone");
            activeEnemies.RemoveAll(enemy => enemy == null);
        }
    }

/*    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (TryGetComponent(out Collider2D col))
            Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
    }*/

}
