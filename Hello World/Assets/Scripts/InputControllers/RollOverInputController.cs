using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollOverInputController : MonoBehaviour
{
    public PauseMenuController pauseMenu;
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.RollOver.Pause.performed += ctx => pauseMenu.PauseInput();
    }

    private void OnEnable()
    {
        controls.RollOver.Enable();
    }

    private void OnDisable()
    {
        controls.RollOver.Disable();
    }
}
