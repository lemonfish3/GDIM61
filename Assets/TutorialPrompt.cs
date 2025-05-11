using UnityEngine;

public class TutorialPrompt : MonoBehaviour
{
    public GameObject prompt;

    public void ShowPrompt()
    {
        prompt.SetActive(true);
    }

    public void HidePrompt()
    {
        prompt.SetActive(false);
    }
}
