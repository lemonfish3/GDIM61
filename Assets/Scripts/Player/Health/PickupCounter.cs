using UnityEngine;
using TMPro;

public class PickupCounter : MonoBehaviour
{
    public static PickupCounter Instance;

    public int itemsCollected = 0;
    public TextMeshProUGUI itemCountText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ItemPickedUp()
    {
        itemsCollected++;
        UpdateItemUI();
    }

    private void UpdateItemUI()
    {
        if (itemCountText != null)
        {
            itemCountText.text = $"Items Collected: {itemsCollected}";
        }
    }
}
