using System.Collections;
using UnityEngine;
using TMPro;

public class PrologueTextManager : MonoBehaviour
{
    public TextMeshProUGUI prologueText;
    public CanvasGroup canvasGroup;

    // Wrapper method to be called by a Timeline signal
    public void ShowIntroText()
    {
        string[] lines = new string[]
        {
            "The journey begins with Vulcana, the young fire witch,",
            "training in the lands across the sea from the continent of Eldara..."
        };

        StartCoroutine(ShowTextSequence(lines));
    }

    // Displays an array of text lines with fade in/out effect
    public IEnumerator ShowTextSequence(string[] lines, float fadeDuration = 1f, float displayTime = 3f)
    {
        foreach (string line in lines)
        {
            prologueText.text = line;
            yield return FadeIn(fadeDuration);
            yield return new WaitForSeconds(displayTime);
            yield return FadeOut(fadeDuration);
        }
    }

    // Fade in canvas group alpha
    IEnumerator FadeIn(float duration)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0, 1, t / duration);
            yield return null;
        }
    }

    // Fade out canvas group alpha
    IEnumerator FadeOut(float duration)
    {
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t / duration);
            yield return null;
        }
    }
}
