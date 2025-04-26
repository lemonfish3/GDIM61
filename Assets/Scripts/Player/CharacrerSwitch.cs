using DG.Tweening.Core.Easing;
using UnityEngine;

public class CharacrerSwitch : MonoBehaviour
{
    public static Transform ActivePlayer { get; private set; }

    public GameObject[] characterPrefabs;
    public FollowingCam cam;

    public HealthBar[] healthBars; // NEW: assign 3 HealthBars in the inspector!
    public GameManager gameManager;  // Reference to the GameManager

    private GameObject[] characterInstances;
    private GameObject currentCharacter;
    private int currentIndex = 0;
    private Vector3 currentPosition;

    void Start()
    {
        characterInstances = new GameObject[characterPrefabs.Length];

        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterInstances[i] = Instantiate(characterPrefabs[i]);
            characterInstances[i].SetActive(false);

            var health = characterInstances[i].GetComponent<PlayerHealth>();
            if (health != null)
            {
                if (i < healthBars.Length)
                    health.healthBar = healthBars[i];

                health.gameManager = gameManager;  // 👈 ADD THIS LINE
            }

            gameManager.AddPlayer(characterInstances[i]);
        }

        SwitchCharacter(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCharacter(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCharacter(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCharacter(2);
    }

    void SwitchCharacter(int index)
    {
        if (currentCharacter != null)
        {
            currentPosition = currentCharacter.transform.position;
            currentCharacter.SetActive(false);
        }
        else
        {
            currentPosition = transform.position;
        }

        currentCharacter = characterInstances[index];
        currentCharacter.transform.position = currentPosition;
        currentCharacter.SetActive(true);
        currentIndex = index;

        if (cam != null)
        {
            cam.player = currentCharacter.transform;
        }

        ActivePlayer = currentCharacter.transform;

        var health = currentCharacter.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.UpdateHealthUI();
        }

        Debug.Log($"Switched to character {index + 1}: {currentCharacter.name}");
    }
}
