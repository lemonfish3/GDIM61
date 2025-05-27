using System.Collections;
using UnityEngine;
using TMPro;

public class CutScene1Manager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public CanvasGroup dialogueGroup;

    private Coroutine currentHideCoroutine;
    private float defaultDisplayTime = 5f; // default time before auto-hiding

    // Call this to show dialogue and auto-hide after a default delay
    public void ShowDialogue(string line)
    {
        ShowDialogue(line, defaultDisplayTime);
    }

    // Overload to show dialogue with custom delay
    public void ShowDialogue(string line, float delay)
    {
        dialogueText.text = line;
        dialogueGroup.alpha = 1;

        // cancel previous coroutine if one is already running
        if (currentHideCoroutine != null)
        {
            StopCoroutine(currentHideCoroutine);
        }

        currentHideCoroutine = StartCoroutine(HideDialogueAfterDelay(delay));
    }

    // Hide the dialogue box
    public void HideDialogue()
    {
        dialogueGroup.alpha = 0;
    }

    // Coroutine to hide dialogue after a delay
    private IEnumerator HideDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        HideDialogue();
        currentHideCoroutine = null;
    }

    // Wrapper methods for Timeline signals — uses default hide delay

public void ShowLine1() { ShowDialogue("Vulcana: So this is where Master told me to go first... I wonder where I should start looking for minions—"); }
    public void ShowLine2() { ShowDialogue("Joanne: HIYAH!!!!!"); }
    public void ShowLine3() { ShowDialogue("Vulcana: ...I guess over there."); }
    public void ShowLine4() { ShowDialogue("Pirate: *pant pant* You'll... never defeat me...! I'll... heh... get you!!!!"); }
    public void ShowLine5() { ShowDialogue("*Crowd murmurs*"); }
    public void ShowLine6() { ShowDialogue("Joanne: Don't be alarmed, everyone, this pirate shall not terrorize us any longer!"); }
    public void ShowLine7() { ShowDialogue("Joanne: I'll be escorting this menace to deal with him... personally."); }
    public void ShowLine8() { ShowDialogue("Pirate: *guuuuulp!*"); }
    public void ShowLine9() { ShowDialogue("Crowd: Oh, thank you Joanne!"); }
    public void ShowLine10() { ShowDialogue("Joanne: No need to thank me, it's all a part of my duty as your guardian. Now, come with me!"); }

    public void ShowLine11() { ShowDialogue("Vulcana: ...Joanne, huh? Seems like she should know about dealing with formidable foes. I should go talk to her."); }
    public void ShowLine12() { ShowDialogue("Joanne: Phew, thanks for that back there. You really got into the role."); }
    public void ShowLine13() { ShowDialogue("Pirate: It’s no problem, it’s what friends do. But you can’t do this forever, Joanne..."); }
    public void ShowLine14() { ShowDialogue("Joanne: *sigh* I know, it’s just…I’m scared. Ever since Master disappeared..."); }
    public void ShowLine15() { ShowDialogue("Pirate: I know it’s scary, Joanne. But those pirates aren’t going anywhere if you don’t do anything about them."); }
    public void ShowLine16() { ShowDialogue("Vulcana: ...So your town needs some help, is that it?"); }
    public void ShowLine17() { ShowDialogue("Joanne: W-who are you and how long have you been standing there?! I mean…what business do you have with me?"); }
    public void ShowLine18() { ShowDialogue("Vulcana: You don’t have to keep up the act. I heard the whole thing."); }
    public void ShowLine19() { ShowDialogue("Joanne: Help?"); }
    public void ShowLine20() { ShowDialogue("Vulcana: Yes. My name is Vulcana. I’m on a mission to defeat the Fallen God’s minions."); }
    public void ShowLine21() { ShowDialogue("Joanne: Fallen God? Minions? I…I don’t know. It seems too dangerous out there."); }
    public void ShowLine22() { ShowDialogue("Vulcana: If you come with me, I won’t tell anyone about anything I heard just now."); }
    public void ShowLine23() { ShowDialogue("Pirate: ...Well, she’s kinda got you there."); }
    public void ShowLine24() { ShowDialogue("Joanne: *sigh* …Fine. I’ll go with you. But not because of that."); }
    public void ShowLine25() { ShowDialogue("Vulcana: Yeah, sure, whatever. Let’s hurry and get a move on."); }
    public void ShowLine26() { ShowDialogue("Vulcana: So, which way to the pirates’ camps?"); }
    public void ShowLine27() { ShowDialogue("Joanne: From what my master told me, they have two—an outpost and a base camp—both north of town."); }
    public void ShowLine28() { ShowDialogue("Vulcana: Great, let's start with the outpost. Lead the way…?"); }
    public void ShowLine29() { ShowDialogue("Joanne: Joanne."); }
    public void ShowLine30() { ShowDialogue("Vulcana: Lead the way, Joanne."); }
    public void ShowLine31() { ShowDialogue("Joanne: That’s the outpost up ahead."); }
    public void ShowLine32() { ShowDialogue("Vulcana: Are you ready to avenge your master?"); }
    public void ShowLine33() { ShowDialogue("Joanne: Avenge? He’s missing, not dead... but yes. I am."); }
    public void ShowLine34() { ShowDialogue("Vulcana: Then let’s go."); }
}