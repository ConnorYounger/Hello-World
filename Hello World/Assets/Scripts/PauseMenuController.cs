using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public Canvas exerciseHUD;
    public Canvas pauseOverlay; 
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
        exerciseHUD.enabled = false;
        pauseOverlay.enabled = true;
        Time.timeScale = 0;

        EventSystem.current.SetSelectedGameObject(resumeButton.gameObject);

        isPaused = true;
    }

    private void ResumeGame()
    {
        //disable pause menu, resume game
        exerciseHUD.enabled = true;
        pauseOverlay.enabled = false;
        Time.timeScale = 1;

        isPaused = false;
    } 

    private void ExitGame()
    {
        //exit scene, load main menu
        SceneManager.LoadScene("F_Menu");
    }
}