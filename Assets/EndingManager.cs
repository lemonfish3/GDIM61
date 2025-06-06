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

        ending2Button.onClick.AddListener(() =>
            SelectEnding("The final blow lands, and the Fallen God—once Ahrmonia, goddess of Harmony—collapses in a storm of fire and ash. As her form fades, she reaches for her daughter, whispering a regretful apology. Vulcana does not flinch. With her mother’s death, the last tether to her divine origins is severed. The corrupted energy that once spread chaos across the land dissipates with her passing. Though the world begins to heal, Vulcana walks away from the ruins not as a savior, but as someone who chose certainty over mercy. She silenced the source of her corruption—but at a cost she will carry forever."));

        ending1Button.onClick.AddListener(() =>
            SelectEnding("Standing over the defeated god, Vulcana hesitates—then lowers her weapon. Reaching out, she channels her fire not to destroy, but to cleanse. The corruption burns away, revealing the true form of Ahrmonia: wounded, but still divine. Through her daughter’s compassion and strength, the goddess reawakens, her mind and spirit restored. A wave of harmony pulses across the land, healing what had been twisted. As light returns to the world, Vulcana knows she could have chosen vengeance—but instead, she chose hope. The fire within her no longer burns for destruction, but for renewal."));
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
