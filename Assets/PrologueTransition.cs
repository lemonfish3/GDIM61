using UnityEngine;
using UnityEngine.SceneManagement;

public class PrologueTransition : MonoBehaviour
{
    public string nextSceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void LoadNextSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
