using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Canvas exerciseCanvas;
    public Canvas pauseCanvas; 
    public Button resumeButton;
    public Button exitButton;

    private void Start()
    {
        //add listeners to buttons
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        //check for pause input
        if (Input.GetButtonDown("p")) //TO DO: update for controller pause input
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        //enable pause menu, pause game
        exerciseCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;

    }

    private void ResumeGame()
    {
        //disable pause menu, resume game
        exerciseCanvas.enabled = true;
        pauseCanvas.enabled = false;
        Time.timeScale = 1; 
    } 

    private void ExitGame()
    {
        //exit scene, load main menu
        SceneManager.LoadScene("Main");
    }
}
