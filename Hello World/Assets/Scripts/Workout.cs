using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
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
    public float failCoolDownTime = 1;
    public float sucessCoolDownTime = 2;
    public float movementMultiplier = 2;
    private float resetCoolDown;
    private float currentHoldTime;

    [Header("Buffers")]
    public float inputYBuffer = 0.05f;
    public float inputXBuffer = 0.05f;
    public float syncBuffer = 0.05f;
    public float synchronisationBuffer = 0.5f;
    private float syncTimer;

    private bool reset;
    private bool gameFinished;
    private bool moveDown;
    private bool checkpoint1Left;
    private bool checkpoint1Right;
    private bool checkpoint2Left;
    private bool checkpoint2Right;

    private Vector2 rightMove;
    private Vector2 leftMove;

    [Space()]
    public ExerciseSoundEffectsManager soundManager;

    [Header("Ui Elements")]
    public Slider sitUpSlider;
    public Slider patienceSlider;

    public GameObject winScreen;
    public GameObject loseScreen;
    public Canvas uIControlls;
    public GameObject uIText;

    public Image[] upControls;
    public Image[] downControls;
    private bool down = true;

    public int uIControllsDisplayCounter = 3;
    private int uIDisplayCounter;

    public Animator animator;

    private Vector3 startingLocation;

    private MiniGameInputs controls;

    public ParentNarrative parent;

    [Header("ControllsUI")]
    public GameObject[] controllerUI;
    public GameObject[] keyboardUI;
    private bool controller;
    public AnalogStickTweener leftAnalogStick;
    public AnalogStickTweener rightAnalogStick;

    [Header("Discovery Player")]
    public bool discoveryMode;
    public DiscoveryPlayer discoveryPlayer;

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
        uIDisplayCounter = uIControllsDisplayCounter;

        StartCoroutine("UIMovement");
        StartCoroutine("StartExerciseWaitTime");

        gameFinished = true;
    }

    public void StartExercise()
    {
        gameFinished = false;
    }

    IEnumerator UIMovement()
    {
        yield return new WaitForSeconds(1);

        if (down)
        {
            leftAnalogStick.StartCoroutine("TiltDown");
            rightAnalogStick.StartCoroutine("TiltDown");
        }
        else
        {
            leftAnalogStick.StartCoroutine("TiltUp");
            rightAnalogStick.StartCoroutine("TiltUp");
        }

        yield return new WaitForSeconds(1);

        StartCoroutine("UIMovement");
    }

    void SetInputActions()
    {
        controls.HoldingObjects.RightHandMovement.performed += ctx => rightMove = ctx.ReadValue<Vector2>();

        controls.HoldingObjects.LeftHandMovement.performed += ctx => leftMove = ctx.ReadValue<Vector2>();

        //
        controls.HoldingObjects.AnyInputCon.performed += ctx => UpdateControllsUI(true);
        controls.HoldingObjects.AxisCon.performed += ctx => UpdateControllsUI(true);
        controls.HoldingObjects.AnyInputKey.performed += ctx => UpdateControllsUI(false);
    }

    void Update()
    {
        if (!gameFinished)
        {
            SitUp();
            CheckForSucessfulSitUp();
        }

        //if(resetCoolDown > 0)
        //{
        //    resetCoolDown -= Time.deltaTime;
        //}

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
        if (!reset)
        {
            // Left Thumb Stick Input
            if (leftMove.y < -1 + inputYBuffer && !checkpoint1Left)
            {
                syncTimer = synchronisationBuffer;

                Debug.Log("Checkpoint 1 Left");
                checkpoint1Left = true;
            }

            if (leftMove.y > 1 - inputYBuffer && checkpoint1Left)
            {
                syncTimer = synchronisationBuffer;

                Debug.Log("Checkpoint 2 Left");
                checkpoint2Left = true;
            }
            //

            // Right Thumb Stick Input
            if (rightMove.y < -1 + inputYBuffer && !checkpoint1Right)
            {
                syncTimer = synchronisationBuffer;

                Debug.Log("Checkpoint 1 Right");
                checkpoint1Right = true;
            }

            if (rightMove.y > 1 - inputYBuffer && checkpoint1Right)
            {
                syncTimer = synchronisationBuffer;

                Debug.Log("Checkpoint 2 Right");
                checkpoint2Right = true;
            }
            //

            if(checkpoint1Left && checkpoint1Right && animator.GetInteger("Stage") == 0)
            {
                animator.SetInteger("Stage", 1);
                down = false;
                UIControlsSwitch();
            }

            if (checkpoint2Left && checkpoint2Right)
            {
                animator.SetInteger("Stage", 2);
                UIControlsSwitch();

                SucessfulSitUp();
            }

            // Check if the player has moved along the x axis
            if ((leftMove.x > inputXBuffer || leftMove.x < -inputXBuffer) || (rightMove.x > inputXBuffer || rightMove.x < -inputXBuffer))
            {
                FailedSitUp();
            }

            SyncTimer();
        }

        if(reset && rightMove == Vector2.zero && leftMove == Vector2.zero && resetCoolDown <= 0)
        {
            reset = false;

            animator.SetBool("FallOverRight", false);
            animator.SetBool("FallOverLeft", false);
            animator.SetBool("GetUp", true);
        }
    }

    void SyncTimer()
    {
        //if(syncTimer > 0 && (((checkpoint1Left && !checkpoint1Right) || (checkpoint1Right && !checkpoint1Left)) || ((checkpoint2Left && !checkpoint2Right) || (checkpoint2Right && !checkpoint2Left))))
        //{
        //    syncTimer -= 1 * Time.deltaTime;
        //}

        //if(syncTimer <= 0 && (((checkpoint1Left && !checkpoint1Right) || (checkpoint1Right && !checkpoint1Left)) || ((checkpoint2Left && !checkpoint2Right) || (checkpoint2Right && !checkpoint2Left))))
        //{
        //    Debug.Log("Sycn Fail, sync timer: " + syncTimer);
        //    FailedSitUp();
        //}

        if(!reset && CalculateBuffer())
        {
            Debug.Log("out of sync");
            //FailedSitUp();
        }

        if (syncTimer > 0 && CalculateBuffer())
        {
            syncTimer -= 1 * Time.deltaTime;
        }

        if (syncTimer <= 0 && CalculateBuffer())
        {
            Debug.Log("Sycn Fail, sync timer: " + syncTimer);
            FailedSitUp();
        }
    }

    bool CalculateBuffer()
    {
        if (Mathf.Abs(leftMove.y - rightMove.y) > syncBuffer)
            return true;
        else
            return false;
    }

    void FailedSitUp()
    {
        animator.SetBool("GetUp", false);
        animator.SetBool("Fail", true);
        StartCoroutine("ResetAnimator");

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
        else
        {
            int rand = Random.Range(0, 2);

            if(rand == 0)
                animator.SetBool("FallOverRight", true);
            else
                animator.SetBool("FallOverLeft", true);
        }

        StartCoroutine("ResetCoolDown", failCoolDownTime);
        //resetCoolDown = resetCoolDownTime;

        reset = true;

        ResetCheckPoints();

        currentHoldTime = 0;

        currentPatience--;

        uIDisplayCounter = uIControllsDisplayCounter;

        UpdateUIControlls();
        UpdateSliders();

        if (currentPatience <= 0)
        {
            Lose();
        }
        else
        {
            parent.PlayFailNarrativeElement();

            if (soundManager)
                soundManager.PlayFailSound();
        }
    }

    IEnumerator ResetAnimator()
    {
        yield return new WaitForSeconds(0.5f);

        animator.SetInteger("Stage", 0);
        animator.SetBool("Fail", false);
        UIControlsSwitch();
    }

    void CheckForSucessfulSitUp()
    {
        if(currentHoldTime >= holdTime)
        {
            SucessfulSitUp();
        }
    }

    void UpdateUIControlls()
    {
        if(uIDisplayCounter <= 0)
        {
            uIDisplayCounter = 0;

            for(int i = 0; i < upControls.Length; i++)
            {
                upControls[i].enabled = false;
                downControls[i].enabled = false;
            }

            leftAnalogStick.gameObject.SetActive(false);
            rightAnalogStick.gameObject.SetActive(false);

            if (uIText)
            {
                //uIText.SetActive(false);
            }
        }
        else
        {
            leftAnalogStick.gameObject.SetActive(true);
            rightAnalogStick.gameObject.SetActive(true);

            if (uIText)
            {
                //uIText.SetActive(true);
            }
        }
    }

    void ModifyUIDisplay(int i)
    {
        if (uIDisplayCounter > 0)
            uIDisplayCounter += i;

        UpdateUIControlls();
    }

    void SucessfulSitUp()
    {
        StartCoroutine("ResetCoolDown", sucessCoolDownTime);

        reset = true;

        //resetCoolDown = resetCoolDownTime;

        sitUpCount++;

        if (parent && sitUpCount < sitUpGoal)
            parent.NarrativeElement(parent.sucessDialougeTexts[sitUpCount - 1]);

        UpdateSliders();

        ModifyUIDisplay(-1);
        ResetCheckPoints();

        if (sitUpCount >= sitUpGoal)
        {
            Win();
        }
        else
        {
            if (soundManager)
                soundManager.PlaySucessSound();
        }

        StartCoroutine("ResetAnimator");
    }

    void ResetCheckPoints()
    {
        checkpoint1Left = false;
        checkpoint1Right = false;
        checkpoint2Left = false;
        checkpoint2Right = false;
        down = true;
    }

    void Win()
    {
        winScreen.SetActive(true);
        uIControlls.enabled = false;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("WinButton"));

        gameFinished = true;

        if (parent)
            parent.NarrativeElement(parent.winText);

        if (soundManager)
            soundManager.PlayWinSound();

        if (discoveryMode)
        {
            discoveryPlayer.exerciseIndex = 2.1f;

            discoveryPlayer.SavePlayer();
        }
    }

    void Lose()
    {
        loseScreen.SetActive(true);
        uIControlls.enabled = false;

        EventSystem.current.SetSelectedGameObject(GameObject.Find("LoseButton"));

        gameFinished = true;

        if (parent)
            parent.NarrativeElement(parent.loseText);

        if (soundManager)
            soundManager.PlayLoseSound();
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

    void UIControlsSwitch()
    {
        if(uIDisplayCounter > 0)
        {
            if (animator.GetInteger("Stage") == 1)
            {
                for (int i = 0; i < upControls.Length; i++)
                {
                    upControls[i].enabled = true;
                    downControls[i].enabled = false;
                }
            }
            else
            {
                for (int i = 0; i < upControls.Length; i++)
                {
                    upControls[i].enabled = false;
                    downControls[i].enabled = true;
                }
            }
        }
    }

    void UpdateControllsUI(bool c)
    {
        //Debug.Log("Update Controlls " + c);

        if (c)
        {
            foreach(GameObject con in controllerUI)
            {
                con.SetActive(true);
            }

            foreach (GameObject key in keyboardUI)
            {
                key.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject con in controllerUI)
            {
                con.SetActive(false);
            }

            foreach (GameObject key in keyboardUI)
            {
                key.SetActive(true);
            }
        }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    IEnumerator ResetCoolDown(float time)
    {
        resetCoolDown = time;

        yield return new WaitForSeconds(time);

        resetCoolDown = 0;
    }
}
