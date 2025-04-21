using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
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
    }

    // Called by PlayerHealth
    public void UpdateHealth(float current, float max)
    {
        float ratio = Mathf.Clamp01(current / max); // ensure it's never negative or >1

        if (ratio <= 0f)
        {
            // Set to zero instantly
            healthBarFillImage.fillAmount = 0f;
            healthBarTrailingFillImage.fillAmount = 0f;
        }
        else
        {
            // Tween as usual
            Sequence sequence = DOTween.Sequence();
            sequence.Append(healthBarFillImage.DOFillAmount(ratio, 0.25f).SetEase(Ease.InOutSine));
            sequence.AppendInterval(trailDelay);
            sequence.Append(healthBarTrailingFillImage.DOFillAmount(ratio, 0.3f).SetEase(Ease.InOutSine));
            sequence.Play();
        }
    }
}
