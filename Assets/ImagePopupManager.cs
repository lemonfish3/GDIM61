using UnityEngine;
using System.Collections;
public class ImagePopupManager : MonoBehaviour
{
    public CanvasGroup puimages;

    public void ShowImage()
    {
        StartCoroutine(FadeCanvasGroup(puimages, 0f, 1f, 1f));
    }

    public void HideImage()
    {
        StartCoroutine(FadeCanvasGroup(puimages, 1f, 0f, 1f));
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            cg.alpha = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cg.alpha = end;
    }
}
