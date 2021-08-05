using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    #region Variables
    private EventSystem eventSystem;
    public DiscoveryPlayer player;
        
    [Header("Menu Canvas")]
    public GameObject shelfCanvas;
    public GameObject cribCanvas;
    public GameObject toyboxCanvas;
    public GameObject changetableCanvas;
    public GameObject playmatCanvas;
    public GameObject doorCanvas;

    [Header("UI Panels")]
    public GameObject panelOptions;
    public GameObject panelDisplay;
    public GameObject panelAudio;

    [Header("UI Buttons")]
    public Button btnPlay;
    public Button btnOptions;
    public Button btnExit;
    public Button btnDisplay;
    public Button btnAudio;
    public Button btnChangeTableBack;
    public Button btnDiscovery;
    public Button btnToyBox;
    public Button btnToyBoxBack;
    public Button btnCycleLeft;
    public Button btnCycleRight;
    public Button btnExercise;
    public Button btnPlaymatBack;
    public Button btnNewGame;
    public Button btnContinue;
    public Button btnCribBack;
    public Button btnExitYes;
    public Button btnExitNo;
    public Button btnDisplayBack;
    public Button btnAudioBack;

    private Animator animator;
    #endregion

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("Shelf");
    }

    private void Start()
    {
        Time.timeScale = 1;

        eventSystem = EventSystem.current;

        ResetCanvasUI();
        
        btnPlay.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });
        btnOptions.onClick.AddListener(delegate { NavigateMenus("Change Table"); });
        btnExit.onClick.AddListener(delegate { NavigateMenus("Door"); });
        
        btnDiscovery.onClick.AddListener(delegate { NavigateMenus("Crib"); });
        btnToyBox.onClick.AddListener(delegate { NavigateMenus("Playmat"); });
        btnToyBoxBack.onClick.AddListener(delegate { NavigateMenus("Shelf"); });

        btnDisplay.onClick.AddListener(DisplayOptions);
        btnAudio.onClick.AddListener(AudioOptions);
        btnChangeTableBack.onClick.AddListener(delegate { NavigateMenus("Shelf"); });
        btnDisplayBack.onClick.AddListener(GoToOptionsTop);
        btnAudioBack.onClick.AddListener(GoToOptionsTop);

        btnNewGame.onClick.AddListener(StartNewDiscovery);
        //btnContinue.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        btnCribBack.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });

        btnPlaymatBack.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });

        btnExitYes.onClick.AddListener(Application.Quit);
        btnExitNo.onClick.AddListener(delegate { NavigateMenus("Shelf"); });
        }

    private void StartNewDiscovery()
    {
        player.exerciseIndex = 0.1f;
        player.cardIndex = "1In";
        player.SavePlayer();
        PlayerPrefs.SetString("gameMode", "Discovery");

        SceneManager.LoadScene("DiscoveryMilestones");
    }

    #region Options Menu
    private void DisplayOptions()
    {
        panelOptions.SetActive(false);
        panelDisplay.SetActive(true);
        eventSystem.SetSelectedGameObject(btnDisplayBack.gameObject, new BaseEventData(eventSystem));
    }

    private void AudioOptions()
    {
        panelOptions.SetActive(false);
        panelAudio.SetActive(true);
        eventSystem.SetSelectedGameObject(btnAudioBack.gameObject, new BaseEventData(eventSystem));
    }

    private void GoToOptionsTop()
    {        
        panelAudio.SetActive(false);
        panelDisplay.SetActive(false);
        panelOptions.SetActive(true);
        eventSystem.SetSelectedGameObject(btnDisplay.gameObject, new BaseEventData(eventSystem));
    }
    #endregion

    private void NavigateMenus(string menuToSwitch)
    {
        switch (menuToSwitch)
        {
            case "Shelf":
                animator.Play("Shelf");
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(shelfCanvas, btnPlay.gameObject));
                break;
            case "Playmat":
                animator.Play("Playmat");
                toyboxCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(playmatCanvas, btnExercise.gameObject));
                break;
            case "Toy Box":
                animator.Play("Toy Box");
                shelfCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(toyboxCanvas, btnDiscovery.gameObject));
                break;
            case "Change Table":
                animator.Play("Change Table");
                shelfCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(changetableCanvas, btnChangeTableBack.gameObject));

                break;
            case "Crib":
                animator.Play("Crib");
                toyboxCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(cribCanvas, btnNewGame.gameObject));
                break;
            case "Door":
                animator.Play("Door");
                shelfCanvas.SetActive(false);
                StartCoroutine(ChangeCanvasUI(doorCanvas, btnExitYes.gameObject));
                break;
            default: break;
        }

    }

    private IEnumerator ChangeCanvasUI(GameObject canvas, GameObject btn)
    {
        yield return new WaitForSeconds(1.5f);
        canvas.SetActive(true);
        eventSystem.SetSelectedGameObject(btn, new BaseEventData(eventSystem));
    }

    private void ResetCanvasUI()
    {
        shelfCanvas.SetActive(true);
        toyboxCanvas.SetActive(false);
        cribCanvas.SetActive(false);
        playmatCanvas.SetActive(false);
        changetableCanvas.SetActive(false);
        doorCanvas.SetActive(false);
    }
}
