using UnityEngine;
using TMPro;


[System.Serializable]
public struct DialogueLine
{
    public string speaker;

    [TextArea(2, 5)]
    public string line;
}

public class NPCDialogue : MonoBehaviour
{
    public DialogueLine[] dialogueLines;

    public KeyCode dialogueKey = KeyCode.X;
    public float displayRadius = 1.5f;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI speakerName;
    public GameObject talkPromptUI;
    public GameObject powerUpPanel;

    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogueActive = false;
    private bool justStartedDialogue = false;

    private void Start()
    {
        dialoguePanel.SetActive(false);
        if (talkPromptUI != null )
        {
            talkPromptUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacrerSwitch.ActivePlayer == null) return;

        float distance = Vector2.Distance(transform.position, CharacrerSwitch.ActivePlayer.position);
        playerInRange = distance <= displayRadius;

        if (playerInRange && !dialogueActive)// set ui active if player in range
            talkPromptUI?.SetActive(true);
        else
            talkPromptUI?.SetActive(false);


        if (playerInRange && !dialogueActive && Input.GetKeyDown(dialogueKey)) // set up dialogue panel
        {
            StartDialogue();
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(dialogueKey)  && dialogueActive && !justStartedDialogue)
        {
            AdvanceDialogue();
        }

        if (justStartedDialogue && Input.GetKeyDown(dialogueKey)) // make sure press key won't skip lines
        {
            justStartedDialogue = false;
        }
    }

    void DisplayCurrentLine()
    {
        dialogueText.text = dialogueLines[currentLine].line;
        if (speakerName != null)
        {
            speakerName.text = dialogueLines[currentLine].speaker;
        }
    }

    void StartDialogue()
    {
        dialogueActive = true; 
        currentLine = 0;
        dialoguePanel.SetActive(true);
        powerUpPanel.SetActive(false);
        // talkPromptUI.SetActive(false);
        DisplayCurrentLine();
        justStartedDialogue = true;
        Debug.Log($"first line{currentLine}");
    }

    void AdvanceDialogue()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            Debug.Log("End of dialogue reached.");
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueActive=false;
        currentLine = 0;
        dialoguePanel.SetActive(false);
        powerUpPanel.SetActive(true );
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, displayRadius);
    }
}
