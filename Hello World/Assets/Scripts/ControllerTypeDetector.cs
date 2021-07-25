using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTypeDetector : MonoBehaviour
{
    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        SetInputActions();
    }

    void SetInputActions()
    {
        controls.ControllerDetector.Xbox.performed += ctx => XboxController();
        controls.ControllerDetector.PS.performed += ctx => PSController();
    }

    void XboxController()
    {
        // set string = "Xbox"
        PlayerPrefs.SetString("ControlType", "Xbox");
    }

    void PSController()
    {
        // set string = "ps"
        PlayerPrefs.SetString("ControlType", "PS");
    }

    private void OnEnable()
    {
        controls.ControllerDetector.Enable();
    }

    private void OnDisable()
    {
        controls.ControllerDetector.Disable();
    }
}
