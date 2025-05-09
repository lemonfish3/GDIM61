using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarFillImage;
    [SerializeField] private Image healthBarTrailingFillImage;
    [SerializeField] private float trailDelay = 0.4f;
    [SerializeField] private float maxHealth = 100f;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBarFillImage.fillAmount = 1f;
        healthBarTrailingFillImage.fillAmount = 1f;

        /*Canvas canvas = GetComponentInChildren<Canvas>();
        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            canvas.worldCamera = Camera.main;
        }*/
    }

    void Start()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        if (canvas != null && canvas.renderMode == RenderMode.WorldSpace)
        {
            canvas.worldCamera = Camera.main;
        }
    }

    public void UpdateHealth(float current, float max)
    {
        float ratio = Mathf.Clamp01(current / max);
        currentHealth = current;
        maxHealth = max;

        if (ratio <= 0f)
        {
            healthBarFillImage.fillAmount = 0f;
            healthBarTrailingFillImage.fillAmount = 0f;
        }
        else
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(healthBarFillImage.DOFillAmount(ratio, 0.25f).SetEase(Ease.InOutSine));
            sequence.AppendInterval(trailDelay);
            sequence.Append(healthBarTrailingFillImage.DOFillAmount(ratio, 0.3f).SetEase(Ease.InOutSine));
            sequence.Play();
        }

    }

}
