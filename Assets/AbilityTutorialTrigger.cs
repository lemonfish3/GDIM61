using UnityEngine;

public class AbilityTutorialTrigger : MonoBehaviour
{
    public KeyCode abilityKey = KeyCode.X;
    public GameObject dummy;
    public GameObject player;
    public GameObject nextStepTrigger;

    private bool abilityUnlocked = false;

    void Update()
    {
        if (abilityUnlocked && Input.GetKeyDown(abilityKey))
        {
            // Simulate ability being used and dummy being hit
            if (Vector3.Distance(player.transform.position, dummy.transform.position) < 3f)
            {
                dummy.SetActive(false);
                nextStepTrigger.SetActive(true);
            }
        }
    }

    public void UnlockAbility()
    {
        abilityUnlocked = true;
    }
}