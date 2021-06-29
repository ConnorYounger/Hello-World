using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCameraSwitcher : MonoBehaviour
{
    [Header("Menu Canvas")]
    public GameObject shelfCanvas;
    public GameObject cribCanvas;
    public GameObject toyboxCanvas;
    public GameObject changetableCanvas;
    public GameObject playmatCanvas;
    public GameObject doorCanvas;
    
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

        // Update these calls with UI selection
        cam1.performed += _ => SwitchCamera("cam1");
        cam2.performed += _ => SwitchCamera("cam2");
        cam3.performed += _ => SwitchCamera("cam3");
        cam4.performed += _ => SwitchCamera("cam4");
        cam5.performed += _ => SwitchCamera("cam5");
        cam6.performed += _ => SwitchCamera("cam6");
    }

    private void SwitchCamera(string camToSwitch)
    {
        switch (camToSwitch)
        {
            case "cam1":
                animator.Play("Shelf");

                playmatCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(shelfCanvas));
                break;
            case "cam2":
                animator.Play("Playmat");
                
                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(playmatCanvas));
                break;
            case "cam3":
                animator.Play("Toy Box");

                shelfCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(toyboxCanvas));
                break;
            case "cam4":
                animator.Play("Change Table");

                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                cribCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                doorCanvas.SetActive(false);

                StartCoroutine(ChangeCanvasUI(changetableCanvas));
                break;
            case "cam5":
                animator.Play("Crib");

                shelfCanvas.SetActive(false);
                toyboxCanvas.SetActive(false);
                playmatCanvas.SetActive(false);
                changetableCanvas.SetActive(false);
                doorCanvas.SetActive(false);
                
                StartCoroutine(ChangeCanvasUI(cribCanvas));
                break;
            case "cam6":
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
