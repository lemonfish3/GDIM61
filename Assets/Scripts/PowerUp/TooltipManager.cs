using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipObject;
    public TextMeshProUGUI tooltipText;
    public Vector2 offset = new Vector2(10f, -10f);

    void Awake()
    {
        Instance = this;
        HideTooltip();
    }

    void Update()
    {
        if (tooltipObject.activeSelf)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                tooltipObject.transform.parent as RectTransform,
                Input.mousePosition, null, out pos);
            tooltipObject.GetComponent<RectTransform>().anchoredPosition = pos + offset;
        }
    }

    public void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipObject.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltipObject.SetActive(false);
    }
}
