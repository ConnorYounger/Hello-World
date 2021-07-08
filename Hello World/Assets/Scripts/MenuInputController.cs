
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputController : MonoBehaviour
{
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();
    }

    private void OnEnable()
    {
        controls.MainMenu.Enable();
    }

    private void OnDisable()
    {
        controls.MainMenu.Disable();
    }
}