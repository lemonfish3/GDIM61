using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;

public class MainMenu : MonoBehaviour
{
    public void PlayGame () {
        Time.timeScale = 1f;
        SceneManager.LoadScene("World 1");
    }

    public void QuitGame() {
        Debug.Log ("QUIT");
        Application.Quit();
    }
}
