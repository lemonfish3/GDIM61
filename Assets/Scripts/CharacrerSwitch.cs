using UnityEngine;

public class CharacrerSwitch : MonoBehaviour
{
    public GameObject[] characterPrefabs; // list of prefabs
    public FollowingCam cam;

    private GameObject[] characterInstances; // list of character(initialized)
    private GameObject currentCharacter; 
    private int currentIndex = 0;
    private Vector3 currentPosition;

    // called when player press numbers(1-3)
    void SwitchCharacter(int index)
    {   
        // get position of the current character
        if (currentCharacter != null) 
        {
            currentPosition = currentCharacter.transform.position;
            currentCharacter.SetActive(false); // inactivate current character
        }
        else 
        {
            currentPosition = transform.position;
        }

        currentCharacter = characterInstances[index]; // update to current character
        currentCharacter.transform.position = currentPosition; // update position
        currentCharacter.SetActive(true); // set active
        currentIndex = index; // update index
        
        if (cam != null)
        {
            cam.player = currentCharacter.transform; // make sure camera follows current character
        }
        Debug.Log($"Switched to character {index + 1}: {currentCharacter.name}");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // initialize all characters and set them inactive
        characterInstances = new GameObject[characterPrefabs.Length];
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterInstances[i] = Instantiate(characterPrefabs[i]);
            characterInstances[i].SetActive(false);
        }

        SwitchCharacter(0);
    }
    
    // Update is called once per frame
    void Update()
    {
        // get player's input
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchCharacter(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchCharacter(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchCharacter(2);
    }
}
