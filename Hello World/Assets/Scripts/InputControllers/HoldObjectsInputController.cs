using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoldObjectsInputController : MonoBehaviour
{
    public PauseMenuController pauseMenu;
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.Pause.performed += ctx => pauseMenu.PauseInput();
    }

    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }
}
