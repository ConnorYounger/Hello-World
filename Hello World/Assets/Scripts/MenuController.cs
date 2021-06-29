using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("Menu Canvas")]
    public GameObject shelfCanvas;
    public GameObject cribCanvas;
    public GameObject toyboxCanvas;
    public GameObject changetableCanvas;
    public GameObject playmatCanvas;
    public GameObject doorCanvas;

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

    [Header("Camera keys")]
    public InputAction cam1;
    public InputAction cam2;
    public InputAction cam3;
    public InputAction cam4;
    public InputAction cam5;
    public InputAction cam6;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("Shelf");
    }

    private void OnEnable()
    {
        cam1.Enable();
        cam2.Enable();
        cam3.Enable();
        cam4.Enable();
        cam5.Enable();
        cam6.Enable();
    }

    private void OnDisable()
    {
        cam1.Disable();
        cam2.Disable();
        cam3.Disable();
        cam4.Disable();
        cam5.Disable();
        cam6.Disable();
    }

    private void Start()
    {
        ResetCanvasUI();
        
        btnPlay.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });
        btnOptions.onClick.AddListener(delegate { NavigateMenus("Change Table"); });
        btnExit.onClick.AddListener(delegate { NavigateMenus("Door"); });
        
        btnDiscovery.onClick.AddListener(delegate { NavigateMenus("Crib"); });
        btnToyBox.onClick.AddListener(delegate { NavigateMenus("Playmat"); });
        btnToyBoxBack.onClick.AddListener(delegate { NavigateMenus("Shelf"); });
        
        //btnDisplay.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        //btnAudio.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        btnChangeTableBack.onClick.AddListener(delegate { NavigateMenus("Shelf"); });
        
        //btnNewGame.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        //btnContinue.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        btnCribBack.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });

        //btnCycleLeft.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        //btnCycleRight.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        //btnExercise.onClick.AddListener(delegate { NavigateMenus("xxx"); });
        btnPlaymatBack.onClick.AddListener(delegate { NavigateMenus("Toy Box"); });

        btnExitYes.onClick.AddListener(Application.Quit);
        btnExitNo.onClick.AddListener(delegate { NavigateMenus("Shelf"); });

        // Update these calls with UI selection
        cam1.performed += _ => NavigateMenus("cam1");
        cam2.performed += _ => NavigateMenus("cam2");
        cam3.performed += _ => NavigateMenus("cam3");
        cam4.performed += _ => NavigateMenus("cam4");
        cam5.performed += _ => NavigateMenus("cam5");
        cam6.performed += _ => NavigateMenus("cam6");
    }

    private void NavigateMenus(string menuToSwitch)
    {
        switch (menuToSwitch)
        {
            case "Shelf":
                animator.Play("Shelf");

                playmatCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(shelfCanvas));
                break;
            case "Playmat":
                animator.Play("Playmat");
                
                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(playmatCanvas));
                break;
            case "Toy Box":
                animator.Play("Toy Box");

                shelfCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(toyboxCanvas));
                break;
            case "Change Table":
                animator.Play("Change Table");

                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(changetableCanvas));
                break;
            case "Crib":
                animator.Play("Crib");

                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);
                
                StartCoroutine(ChangeCanvasUI(cribCanvas));
                break;
            case "Door":
                animator.Play("Door");

                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                changetableCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(doorCanvas));
                break;
            default: break;
        }

    }

    private IEnumerator ChangeCanvasUI(GameObject canvas)
    {
        yield return new WaitForSeconds(1.5f);
        canvas.SetActive(true);
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