using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] dialogueLines;

    public KeyCode dialogueKey = KeyCode.Space;
    public float displayRadius = 1.5f;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public GameObject talkPromptUI;

    private int currentLine = 0;
    private bool playerInRange = false;
    private bool dialogueActive = false;

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
        // if (CharacrerSwitch.ActivePlayer == null) return;

        float distance = Vector2.Distance(transform.position, CharacrerSwitch.ActivePlayer.position);
        playerInRange = distance <= displayRadius;

        if (playerInRange && !dialogueActive && Input.GetKeyDown(dialogueKey))
        {
            
            StartDialogue();
        }

        if (Input.GetMouseButtonDown(0)  && dialogueActive)
        {
            AdvanceDialogue();
        }
    }

    void StartDialogue()
    {
        dialogueActive = true; 
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[currentLine];
        Debug.Log($"first line{currentLine}");
    }

    void AdvanceDialogue()
    {
        currentLine++;
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine];
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, displayRadius);
    }
}
