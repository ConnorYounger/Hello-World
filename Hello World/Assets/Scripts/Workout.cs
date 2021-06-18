using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Workout : MonoBehaviour
{
    public GameObject baby;

    public int sitUpGoal = 10;
    private int sitUpCount;
    public int startingPatience = 10;
    private int currentPatience;

    public float tiltAngle = 45;
    public float holdTime = 3;
    private float currentHoldTime;

    private bool reset;
    private bool gameFinished;

    private Vector2 rightMove;
    private Vector2 leftMove;

    public Slider sitUpSlider;
    public Slider patienceSlider;

    public GameObject winScreen;
    public GameObject loseScreen;

    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        currentPatience = startingPatience;

        SetInputActions();
    }

    private void Start()
    {
        sitUpSlider.maxValue = sitUpGoal;
        patienceSlider.maxValue = startingPatience;
    }

    void SetInputActions()
    {
        controls.HoldingObjects.RightHandMovement.performed += ctx => rightMove = ctx.ReadValue<Vector2>();

        controls.HoldingObjects.LeftHandMovement.performed += ctx => leftMove = ctx.ReadValue<Vector2>();
    }

    void Update()
    {
        if (!gameFinished)
        {
            SitUp();
            CheckForSucessfulSitUp();
        }
    }


    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }

    void SitUp()
    {
        if(Mathf.Abs(rightMove.y) > (tiltAngle / 100) && Mathf.Abs(leftMove.y) > (tiltAngle / 100) && !reset)
        {
            currentHoldTime += Time.deltaTime;
        }
        else if (currentHoldTime > 0)
        {
            if (reset)
            {
                currentHoldTime = 0;
            }
            else
            {
                FailedSitUp();
            }
        }

        if(reset && rightMove == Vector2.zero && leftMove == Vector2.zero)
        {
            reset = false;
        }
    }

    void FailedSitUp()
    {
        reset = true;

        currentHoldTime = 0;

        currentPatience--;

        UpdateSliders();

        if (currentPatience <= 0)
        {
            Lose();
        }
    }

    void CheckForSucessfulSitUp()
    {
        if(currentHoldTime >= holdTime)
        {
            SucessfulSitUp();
        }
    }

    void SucessfulSitUp()
    {
        reset = true;

        sitUpCount++;

        UpdateSliders();

        if (sitUpCount >= sitUpGoal)
        {
            Win();
        }
    }

    void Win()
    {
        winScreen.SetActive(true);

        gameFinished = true;
    }

    void Lose()
    {
        loseScreen.SetActive(true);

        gameFinished = true;
    }

    void UpdateSliders()
    {
        sitUpSlider.value = sitUpCount;
        patienceSlider.value = currentPatience;
    }
}
