using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Workout : MonoBehaviour
{
    public GameObject baby;

    public int sitUpGoal = 10;
    private int sitUpCount;
    public int startingPatience = 10;
    private int currentPatience;

    public float tiltAngle = 45;
    public float holdTime = 3;
    public float resetCoolDownTime = 2;
    public float movementMultiplier = 2;
    private float resetCoolDown;
    private float currentHoldTime;

    private bool reset;
    private bool gameFinished;
    private bool moveDown;

    private Vector2 rightMove;
    private Vector2 leftMove;

    [Header("Ui Elements")]
    public Slider sitUpSlider;
    public Slider patienceSlider;

    public GameObject winScreen;
    public GameObject loseScreen;

    public Animator animator;

    private Vector3 startingLocation;

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

        startingLocation = baby.transform.position;
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

        if(resetCoolDown > 0)
        {
            resetCoolDown -= Time.deltaTime;
        }

        MoveToStartingPos();
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

            if(!moveDown)
                baby.transform.position = new Vector3(baby.transform.position.x, baby.transform.position.y + Time.deltaTime * movementMultiplier, baby.transform.position.z);
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

        if(reset && rightMove == Vector2.zero && leftMove == Vector2.zero && resetCoolDown <= 0)
        {
            reset = false;

            animator.SetBool("FallOverRight", false);
            animator.SetBool("FallOverLeft", false);
            animator.SetBool("GetUp", true);
        }
    }

    void FailedSitUp()
    {
        animator.SetBool("GetUp", false);

        moveDown = true;

        if (Mathf.Abs(rightMove.y) < (tiltAngle / 100))
        {
            animator.SetBool("FallOverRight", true);
            Debug.Log("Tilt Right");
        }
        else if (Mathf.Abs(leftMove.y) < (tiltAngle / 100))
        {
            animator.SetBool("FallOverLeft", true);
            Debug.Log("Tilt Left");
        }

        resetCoolDown = resetCoolDownTime;

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

        moveDown = true;

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

    void MoveToStartingPos()
    {
        if (moveDown)
        {
            if (baby.transform.position.y > startingLocation.y)
            {
                baby.transform.position = new Vector3(baby.transform.position.x, baby.transform.position.y - Time.deltaTime * movementMultiplier, baby.transform.position.z);

                Debug.Log("Move Down");
            }

            if (baby.transform.position.y < startingLocation.y)
            {
                baby.transform.position = new Vector3(baby.transform.position.x, startingLocation.y, baby.transform.position.z);

                moveDown = false;
            }
        }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
