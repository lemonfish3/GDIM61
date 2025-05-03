using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PickupCounter.Instance != null)
            {
                PickupCounter.Instance.ItemPickedUp();
            }

            Destroy(gameObject);
        }
    }
}
