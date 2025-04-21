using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y; // keep height the same
        transform.position = newPosition;

        // optional: rotate with player
        // transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}
