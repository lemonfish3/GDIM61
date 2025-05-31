using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI dialogueText;
    public float interval = 5f;
    public PlayableDirector director;

    private string[] dialogueLines = new string[]
{
    " ",
    "Joanne: ...you know, Vulcana, I think I’m starting to get the hang of this. I really don’t know why I let my fears get the better of me. That felt amazing!",
    "Vulcana: Trust me, there will be much worse ahead…but you did good. These are the ancient ruins, a frequent spot for all worshippers alike. The boundary between the mortal and godly realms is thin here, so many gods have been worshipped in its temples throughout history. If I’m not mistaken, we should find more of the Fallen God’s corruption–and maybe some answers.",
    " ",
    "Joanne: Hold on…she doesn’t seem like she’s in good condition.",
    "Vulcana: So? It means it’ll be easier to defeat her if she’s one of the Fallen God’s lackeys.",
    "Joanne: Well, we don’t know that!",
    "Vulcana: Better safe than sorry. I’m going for it.",
    "Joanne: How about this? I’ll go talk to her. You can ready your guard so that if she attacks me, you’ll be ready to strike.",
    " ",
    "Joanne: Excuse me, are you alright?",
    " ",
    "Moriko: They…they took them all..! All my friends! They’ve all…they’ve all..! And now you’re..!",
    " ",
    "Joanne: Hey, it’s okay. No one’s here to hurt you, we just want to know what happened.",
    " ",
    "Moriko: ...My friends…the Fallen God’s minions…they corrupted them all. They’ve been terrorizing our land, so we wanted to fight all of them off–but we weren’t prepared for their strength. Now I’m the last one remaining…",
    " ",
    "Vulcana: The Fallen God’s minions? You fought them? Do you know where they are now?",
    "Moriko: I’m not sure of their exact whereabouts, but they aren’t coming from here. As for where they are now…the last thing I could gather was that they were going to return to the temple deep in the ruins.",
    "Vulcana: Could you take us there? We’re on a mission to defeat all of the Fallen God’s minions and stop this corruption once and for all.",
    " ",
    "Moriko: ...Yes, I can lead you there. But please, let me join you. I…I need to avenge my friends. I have to. I don’t think I can continue without having the peace of mind that I served them justice. So, please…let me fight alongside you.",
    " ",
    "Joanne: I think we should let her fight with us. She’s been through so much, it wouldn’t be fair to leave her here after everything…",
    "Vulcana: I’m still not sure if we can trust her…I’m fine with her leading us to the temple, but fighting with us? I just don’t want to risk anything on such an important mission.",
    "Joanne: Hey, if she ever attacks us, there are always 2 of us and 1 of her. You trusted me to be your companion, so shouldn’t we also give her a chance, too? And with the possibility that she just wants some sort of closure for her lost friends, I’d rather help her than leave her.",
    "Vulcana: Alright, alright, you make your point clear.",
    " ",
    "Vulcana: You can come with us. But know that it’s going to be a grueling journey ahead, so prepare yourself.",
    "Joanne: Wait, now that you’re joining us, I’ve realized that we haven’t yet introduced ourselves. I’m Joanne, this is Vulcana, and you are..?",
    "Moriko: My name is Moriko. Pleasure to work with you.",
    "Vulcana: We should hurry along now. The more time we spend here, the less time we have to get rid of all the Fallen God’s minions.",
    " "
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
