using UnityEngine;
using UnityEngine.InputSystem;

public class MenuCameraSwitcher : MonoBehaviour
{
    [Header("Main Camera")]
    public GameObject mainCam;

    [Header("Menu Cameras")]
    public GameObject shelfCam;
    public GameObject cribCam;
    public GameObject toyboxCam;
    public GameObject changetableCam;
    public GameObject playmatCam;
    public GameObject doorCam;

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
                break;
            case "cam2":
                animator.Play("Playmat");
                break;
            case "cam3":
                animator.Play("Toy Box");
                break;
            case "cam4":
                animator.Play("Change Table");
                break;
            case "cam5":
                animator.Play("Crib");
                break;
            case "cam6":
                animator.Play("Door");
                break;
            default: break;
        }

    }
}
