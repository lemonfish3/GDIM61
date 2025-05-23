using UnityEngine;
using TMPro;

public class PickupCounter : MonoBehaviour
{
    public static PickupCounter Instance;

    public int itemsCollected = 0;
    public int itemsRequired = 5;
    public TextMeshProUGUI itemCountText;
    public GameObject questCompleteScreen; // display question completion

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        UpdateItemUI();
        if (questCompleteScreen != null)
            questCompleteScreen.SetActive(false);
    }

    public void ItemPickedUp()
    {
        itemsCollected++;
        UpdateItemUI();
        if (itemsCollected >= itemsRequired)
        {
            QuestCompleted();
        }
    }

    private void QuestCompleted()
    {
        Time.timeScale = 0f; // Pause the game
        if (questCompleteScreen != null)
            questCompleteScreen.SetActive(true);
    }

    private void UpdateItemUI()
    {
        if (itemCountText != null)
        {
            itemCountText.text = $"Items Collected: {itemsCollected} / {itemsRequired}";
        }
    }

}
