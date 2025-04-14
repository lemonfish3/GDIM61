using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float screenWidth = 10f;
    public float screenHeight = 10f;

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;   
    }

    public void CheckCameraShift(Vector2 playerPosition)
    {
        Vector3 newCameraPosition = transform.position;

        if (playerPosition.y >= startPosition.y + screenHeight / 2)
        {
            newCameraPosition.y += screenHeight;
        }
        if (playerPosition.y <= startPosition.y - screenHeight / 2)
        {
            newCameraPosition.y -= screenHeight;
        }
        if (playerPosition.x >= startPosition.x + screenWidth / 2)
        {
            newCameraPosition.x += screenWidth;
        }
        if (playerPosition.x <= startPosition.x - screenWidth / 2)
        {
            newCameraPosition.x -= screenWidth;
        }
        if (newCameraPosition != transform.position){
            transform.position = newCameraPosition;
            startPosition = newCameraPosition;
            Debug.Log($"Camera moved to: {transform.position}");
        }

    }

}
