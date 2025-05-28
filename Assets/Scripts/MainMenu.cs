using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;

public class MainMenu : MonoBehaviour
{
    public GameObject creditBoard;

    private void Start()
    {
        creditBoard.SetActive(false);
    }

    public void PlayGame () {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Prologue");
    }
    // public void ShowCredits() {
    //     creditsPanel.SetActive(true);
    // }

    // public void HideCredits() {
    //     creditsPanel.SetActive(false);
    // }
    public void QuitGame() {
        Debug.Log ("QUIT");
        Application.Quit();
    }

    public void Credit ()
    {
        creditBoard.SetActive(true);
    }
    public void Main()
    {
        creditBoard.SetActive(false);
    }
}
