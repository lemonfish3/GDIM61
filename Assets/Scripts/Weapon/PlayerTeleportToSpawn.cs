using UnityEngine;

public class PlayerTeleportToSpawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public KeyCode teleportKey = KeyCode.E;

    void Start()
    {
        // auto-populate spawn points if not set manually
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            GameObject[] points = GameObject.FindGameObjectsWithTag("SpawnPoint");
            spawnPoints = new Transform[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                spawnPoints[i] = points[i].transform;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(teleportKey) && spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length);
            transform.position = spawnPoints[randomIndex].position;
        }
    }
}
