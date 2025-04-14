using UnityEngine;

public class FollowingCam : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float smoothSpeed = 5f; // Adjust for smooth camera movement
    private Vector3 offset; // Distance between camera and player

    void Start()
    {
        // Set the initial offset based on the player's position
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        
        // Calculate the target position
        Vector3 targetPosition = player.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
    
    }
}
