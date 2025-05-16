using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
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

    public void ShowLine1()    { ShowDialogue("Very good Vulcana, you seem to be progressing faster than expected. Would you like to move on to the next step of your training?"); }
    public void ShowLine2()    { ShowDialogue("Yes master, I would be honored."); }
    public void ShowLine2_1()  { ShowDialogue("Very well, use Q to attack the dummy and WASD to move around."); }
    public void ShowLine3()    { ShowDialogue("That felt amazing…was it as great as it looked, master?"); }
    public void ShowLine4()    { ShowDialogue("Yes, Vulcana. You're progressing at an unprecedented pace, but let's call it there for today."); }
    public void ShowLine5()    { ShowDialogue("Good morning Master, will I be moving forward to the next step of my training today?"); }
    public void ShowLine6()    { ShowDialogue("Indeed you will be, today I will be teaching you how to use these special gifts from me called powerups."); }
    public void ShowLine7()    { ShowDialogue("You will have the option to use these four powerups, use keys ZXCV to activate them in times of need."); }
    public void ShowLine8()    { ShowDialogue("Yes Master... but may I ask, what does each power up mean?"); }
    public void ShowLine9()    { ShowDialogue("Power up Z is a heal all potion. That will be useful for when you meet other people on your quest."); }
    public void ShowLine10()   { ShowDialogue("Power up X is a shield. Use it to protect yourself against enemies along the way..."); }
    public void ShowLine11()   { ShowDialogue("Power up C is a heal one potion. Make sure to use it once your health begins to run dangerously low."); }
    public void ShowLine12()   { ShowDialogue("Finally, power up V is a sprint potion. It will aid you with getting across the world quicker or help you quickly dodge enemy attacks... Do you understand? "); }
    public void ShowLine13()   { ShowDialogue("Yes Master, I understand and will keep this in mind."); }
    public void ShowLine14()   { ShowDialogue("Very good Vulcana, it appears that your training is not going to waste. Soon you may be able to return home and complete your quest."); }
    public void ShowLine15()   { ShowDialogue("Really? Am I that close?"); }
    public void ShowLine16()   { ShowDialogue("Don't get ahead of yourself, young one, there is still much to learn."); }
    public void ShowLine17()   { ShowDialogue("Vulcana, stop your training. It is time."); }
    public void ShowLine18()   { ShowDialogue("Time for what?"); }
    public void ShowLine19()   { ShowDialogue("We can no longer wait for the right time, it is time for you to return home and complete your test. You are ready. "); }
    public void ShowLine20()   { ShowDialogue("I will miss you, young one, but you have completed your training. I have nothing left to teach you, it is time you take the next steps on your journey."); }
    public void ShowLine21()   { ShowDialogue("Master..."); }
    public void ShowLine22()   { ShowDialogue("The ferry leaves early tomorrow morning. Come, I will help you pack your things."); }
}
