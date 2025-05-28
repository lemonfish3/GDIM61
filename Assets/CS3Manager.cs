using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneManager3 : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;
    public float interval = 5f;
    public PlayableDirector director;

    private string[] dialogueLines = new string[]
{
    "*They make it to the temple, and Joanne is taken aback. Almost like she notices something or…someone???!!!*",
    "Joanne: “Is…is that..?!”",
    "*Joanne runs ahead and the others try to catch up with her. When the camera catches up to all 3 of them, it pans to the right a bit to show [emo guy] chained to the ground, stationary with his eyes closed. Joanne is staring directly at him*",
    "Joanne: “Master Alden…is that you?!”",
    "*Emo guy opens his eyes, noticing Joanne standing right in front of him*",
    "Master Alden: “Joanne…it is…a pleasure to see you again…”",
    "Joanne: “Are you okay?! What have they done to you?! How do we get you out of—”",
    "Master Alden: “One question at a time, please…I don’t have much energy left…”",
    "Joanne: “M-my apologies, master. Do you think you can at least tell us what happened here?”",
    "Master Alden: “That I can do. When I heard of the Fallen God and her minions, I had to venture out of town immediately. I wanted to do whatever I could to protect our home from any sort of threat, even if it meant I had to go straight to the source. However, on that journey…I fell prey to her worshippers. They captured me and chained me here. They performed some kind of ritual and my energy has been whittling away ever since…all to fuel the Fallen God’s plans, I assume.”",
    "Moriko: “Another victim of the Fallen God…curses…”",
    "Joanne: “I-is there any way we can get you out of here? We need you back home, master!”",
    "Master Alden: “I’m afraid not…the ritual has bound me here. The only release from these shackles is to free my soul, but I will not be able to make it back to our town.”",
    "Joanne: “No…no! How are we…how am I supposed to carry on without you, master?!”",
    "Master Alden: “Take it easy, Joanne…it’s taken so long for us to reunite, yet I can already see so much growth within you. The fact that you’ve made it here to see me right now…you’re really becoming a true warrior.”",
    "Joanne: “Master…”",
    "Moriko: “...you said something about freeing your soul? How do we do that?”",
    "Master Alden: “Yes, to free my soul, you’ll have to defeat all of the Fallen God’s minions in this area. They’re the ones that performed the ritual keeping me bound to this temple, and once that is done, I will be set free.”",
    "Joanne: “...We won’t let you down, master. We’ll get rid of these monsters and defeat the Fallen God once and for all.”",
    "Master Alden: “Wait…I have a final request before you release my soul.”",
    "Joanne: “What is it, master?”",
    "Master Alden: “Please…spare the Fallen God. Do whatever you can to purify her soul, but please…do not kill her. Before I was bound here, I saw a glimpse of who she truly was, and all I can say is that she’s not as merciless as she may seem. The real her is still in there, and I beg of you to help it resurface…”",
    "Joanne: “...understood. We’ll do everything we can to make that happen.”",
    "Master Alden: “Thank you. You should hurry now, I don’t wish to keep you for too long.”",
    "Joanne: “Right. Let’s go, guys.”",
    "*Joanne and the centaur walk off a little bit, but Vulcana stays slightly behind.*",
    "Vulcana: “...spare the Fallen God?”",
    "*Vulcana then catches up to the other two, then gameplay commences*"
};


    void Start()
    {
        director.Play(); // Play Timeline animations
        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        foreach (var line in dialogueLines)
        {
            dialogueText.text = line;
            yield return new WaitForSeconds(interval);
        }

        dialogueText.text = "";
        Debug.Log("Cutscene Finished");
        // Optionally trigger gameplay here
    }
}
