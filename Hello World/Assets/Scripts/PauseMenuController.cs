using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    public Canvas exerciseCanvas;
    public Canvas pauseCanvas; 
    public Button resumeButton;
    public Button exitButton;

    private MiniGameInputs controls;

    private bool isPaused;

    private void Start()
    {
        //add listeners to buttons
        resumeButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void Update()
    {
        //check for pause input
        //if (Input.GetButtonDown("p")) //TO DO: update for controller pause input
        //{
        //    PauseGame();
        //}
    }

    public void PauseInput()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        //enable pause menu, pause game
        exerciseCanvas.enabled = false;
        pauseCanvas.enabled = true;
        Time.timeScale = 0;

        EventSystem.current.SetSelectedGameObject(exitButton.gameObject);

        isPaused = true;
    }

    private void ResumeGame()
    {
        //disable pause menu, resume game
        exerciseCanvas.enabled = true;
        pauseCanvas.enabled = false;
        Time.timeScale = 1;

        isPaused = false;
    } 

    private void ExitGame()
    {
        //exit scene, load main menu
        SceneManager.LoadScene("Main");
    }
}
