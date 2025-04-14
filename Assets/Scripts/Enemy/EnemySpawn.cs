using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public CharacrerSwitch characrerSwitch;
    public int maxEnemies = 3;
    public float spawnInterval = 2f;

    private List<GameObject> activeEnemies = new List<GameObject>();
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        activeEnemies.RemoveAll(enemy =>  enemy == null); // destroy null entries

        if (activeEnemies.Count < maxEnemies && timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
            Debug.Log("new enemy");
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab);
        activeEnemies.Add(newEnemy);
    }
}
