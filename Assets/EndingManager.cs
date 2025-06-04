using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Playables;
using System.Collections;
public class EndingManager : MonoBehaviour
{
    public GameObject choicePanel;
    public Button ending1Button;
    public Button ending2Button;
    public TextMeshProUGUI endingText;
    public PlayableDirector cutsceneDirector;

    private void Start()
    {
        choicePanel.SetActive(false);
        endingText.gameObject.SetActive(false);

        ending1Button.onClick.AddListener(() =>
            SelectEnding("You chose to save the world. Peace and harmony return."));

        ending2Button.onClick.AddListener(() =>
            SelectEnding("You chose to rule the world. Darkness spreads under your command."));
    }

    // Call this from Timeline using a signal
    public void ShowChoices()
    {
        cutsceneDirector.Pause(); // Pause cutscene
        choicePanel.SetActive(true);
    }

    private void SelectEnding(string text)
    {
        choicePanel.SetActive(false);
        endingText.text = text;
        endingText.gameObject.SetActive(true);
        StartCoroutine(FadeInText());
    }

    private IEnumerator FadeInText()
{
    Color c = endingText.color;
    float duration = 2f;
    float t = 0f;

    while (t < duration)
    {
        t += Time.deltaTime;
        c.a = Mathf.Lerp(0f, 1f, t / duration);
        endingText.color = c;
        yield return null;
    }

    // ensure final alpha is fully visible
    c.a = 1f;
    endingText.color = c;
}

    
}
