using UnityEngine;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1f;

    public void FadeOut()
    {
        StartCoroutine(Fade(0, 1));
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(1, 0));
    }

    public void FadeOutThenIn()
    {
        StartCoroutine(FadeOutAndIn());
    }

    private IEnumerator FadeOutAndIn()
    {
        yield return Fade(0, 1);
        yield return new WaitForSeconds(1f); // hold black screen
        yield return Fade(1, 0);
    }

    private IEnumerator Fade(float from, float to)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, time / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = to;
    }
}