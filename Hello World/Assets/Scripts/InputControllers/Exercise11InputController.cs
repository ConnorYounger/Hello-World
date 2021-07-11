using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Exercise11InputController : MonoBehaviour
{
    public PauseMenuController pauseMenu;
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.SimonSays.Pause.performed += ctx => pauseMenu.PauseInput();
    }

    private void OnEnable()
    {
        controls.SimonSays.Enable();
    }

    private void OnDisable()
    {
        controls.SimonSays.Disable();
    }
}
