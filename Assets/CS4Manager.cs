using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneManager4 : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;
    public float interval = 5f;
    public PlayableDirector director;

    private string[] dialogueLines = new string[]
{
    "*they approach the entrance to the Fallen God’s lair/where quest 3 takes place*",
    "Vulcana: Wait. Before we go further, there’s something I need to share with both of you.",
    "Moriko: What is it?",
    "Joanne: Don’t tell me you're going to quit when we’re so close to the end.",
    "Vulcana: No! It’s not that, I just–I haven’t been honest with you about the intent of my quest.",
    "Joanne: What do you mean…?",
    "Vulcana: Well, I guess I’ll start from the beginning. From before the Fallen God fell.",
    "Vulcana: Back then, her name was Ahrmonia. She was kind and benevolent…the god of Harmony. Her influence radiated throughout the realm, pushing the mortals to live in peace with one another and the nature that surrounded them.",
    "Vulcana: Of course, discord still found its way in. People grew hungry for power and influence…Ahrmonia was able to keep the peace for some time, but it wouldn’t last.",
    "Vulcana: One day, the humans found an entrance to the godly realm. That was the day the era of peace came to an end.",
    "Vulcana: The humans invaded, vying for Ahrmonia’s power, killing her son–Emor–and kidnapping her daughter in the process.",
    "Vulcana: Ahrmonia was grief stricken. But that grief quickly turned to fury. She let it consume her…corrupt her…and she fell. The Fallen God was born–the god of Discord.",
    "Vulcana: My quest to defeat her minions was so I could weaken and defeat her…freeing her from this suffering.",
    "Joanne: Oh gods…",
    "Moriko: How do you know all this, Vulcana?",
    "Vulcana: …",
    "Vulcana: Because I am the daughter who was kidnapped.",
    "Moriko: YOU’RE THE DAUGHTER OF THE FALLEN GOD?!",
    "Joanne: Moriko, calm down..! She’s still the same Vulcana!",
    "Moriko: BUT HER MOM, SHE–",
    "Vulcana: I am not my mother, Moriko. I know the things she and her minions have done have hurt you–both of you. But I intend to right those wrongs.",
    "Moriko: I– I suppose you’re right. I’m sorry, Vulcana.",
    "Joanne: Wait–Vulcana, you don’t mean to tell me you’re going to…",
    "Vulcana: Yes. I am going to kill my mother.",
    "Joanne: No! My master said her true self was still in there! We need to purify her!",
    "Vulcana: I–",
    "Moriko: How about we weaken her and decide then? We need to see the state she’s in for ourselves, then we can decide.",
    "Joanne & Vulcana: *nod in agreement*",
    "Vulcana: This is it then.",
    "Joanne: …for Master.",
    "Moriko: …for my friends.",
    "Vulcana: …for Emor…and for you, Mother.",
    "*gameplay commences* - players select ending"
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
