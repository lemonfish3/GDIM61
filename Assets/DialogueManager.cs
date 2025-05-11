using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public CanvasGroup dialogueGroup;

    // Call this to show any dialogue with a string (for general use)
    public void ShowDialogue(string line)
    {
        dialogueText.text = line;
        dialogueGroup.alpha = 1;
    }

    // Hide the dialogue box
    public void HideDialogue()
    {
        dialogueGroup.alpha = 0;
    }

    // Wrapper methods for Timeline signals — no arguments needed

    public void ShowLine1()
    {
        ShowDialogue("Very good Vulcana, you seem to be progressing faster than expected. Would you like to move on to the next step of your training?");
    }

    public void ShowLine2()
    {
        ShowDialogue("Yes master, I would be honored.");
    }

    public void ShowLine2_1()
    {
        ShowDialogue("Here's your first test. Use WASD to move around, and Q to attack the enemy.");
    }
    public void ShowLine3()
    {
        ShowDialogue("That felt amazing…was it as great as it looked, master?");
    }

    public void ShowLine4()
    {
        ShowDialogue("Yes, Vulcana. You're progressing at an unprecedented pace, but let's call it there for today.");
    }

    public void ShowLine5()
    {
        ShowDialogue("Master...");
    }
}
