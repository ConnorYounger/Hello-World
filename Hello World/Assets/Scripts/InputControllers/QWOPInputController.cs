using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QWOPInputController : MonoBehaviour
{
    public PauseMenuController pauseMenu;
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.QWOP.Pause.performed += ctx => pauseMenu.PauseInput();
    }

    private void OnEnable()
    {
        controls.QWOP.Enable();
    }

    private void OnDisable()
    {
        controls.QWOP.Disable();
    }
}
