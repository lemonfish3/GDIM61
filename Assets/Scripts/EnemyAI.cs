using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 3f;
    public float spawnRadius = 10f;

    private Camera cam;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;

        Vector2 randomOffset = Random.insideUnitCircle.normalized * spawnRadius;
        Vector2 spawnPosition = CharacrerSwitch.ActivePlayer.position + (Vector3)randomOffset;

        transform.position = spawnPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Transform player = CharacrerSwitch.ActivePlayer;
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        

        //if (!IsVisibleOnScreen())
        //{
        //    Destroy(gameObject);
        //}
    }

    bool IsVisibleOnScreen()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        return viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1;
    }

}
