using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    [System.Serializable]
    public class PowerUpState
    {
        public PowerUps powerUps;
        public Button uiButton;
        public Image cooldownOverlay;
        public float lastUsedTime = -Mathf.Infinity;
        public bool isActive = false;
    }

    public List<PowerUpState> powerUpStates;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var p in powerUpStates)
        {
            p.uiButton.onClick.AddListener(() => TryActivatePowerUp(p));

            // Ensure no cooldown visuals at start
            p.lastUsedTime = -Mathf.Infinity;
            if (p.cooldownOverlay != null)
            {
                p.cooldownOverlay.fillAmount = 0f;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        foreach(var p in powerUpStates)
        {
            float timeSinceUsed = Time.time - p.lastUsedTime;
            float fill = Mathf.Clamp01((p.powerUps.cooldown - timeSinceUsed) / p.powerUps.cooldown);
            if (p.cooldownOverlay != null)
            {
                p.cooldownOverlay.fillAmount = fill;
            }

            if (Input.GetKeyDown(p.powerUps.key))
            {
                TryActivatePowerUp(p);
            }
        }
    }

    void TryActivatePowerUp(PowerUpState state)
    {
        if (Time.time - state.lastUsedTime < state.powerUps.cooldown || state.isActive) return;

        state.lastUsedTime = Time.time;
        state.isActive = true;

        ApplyEffectToAll(state.powerUps.powerUpName);
        StartCoroutine(RemoveAfterDuration(state));
    }

    IEnumerator RemoveAfterDuration(PowerUpState state)
    {
        yield return new WaitForSeconds(state.powerUps.duration);
        RemoveEffectFromAll(state.powerUps.powerUpName);
        state.isActive = false;
        
    }

    void ApplyEffectToAll(string effectName)
    {
        foreach (var player in FindObjectsByType<PowerUpEffect>(FindObjectsSortMode.None))
        {
            player.ApplyEffect(effectName);
        }
    }

    void RemoveEffectFromAll(string effectName)
    {
        foreach (var player in FindObjectsByType<PowerUpEffect>(FindObjectsSortMode.None))
        {
            player.RemoveEffect(effectName);
        }
    }
}
