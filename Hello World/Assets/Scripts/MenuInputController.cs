using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputController : MonoBehaviour
{
    private MiniGameInputs controls;
    private Vector2 moveCursor;

    private void Awake()
    {
        controls = new MiniGameInputs();
        controls.MainMenu.CursorMovement.performed += ctx => MoveCursor(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        controls.MainMenu.Enable();
    }

    private void OnDisable()
    {
        controls.MainMenu.Disable();
    }

    private void MoveCursor(Vector2 v) { 
        
    }
}
