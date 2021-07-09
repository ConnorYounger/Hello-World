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
        //if(Mathf.Abs(rightMove.y) > (tiltAngle / 100) && Mathf.Abs(leftMove.y) > (tiltAngle / 100) && !reset)
        //{
        //    currentHoldTime += Time.deltaTime;

        //    if(!moveDown)
        //        baby.transform.position = new Vector3(baby.transform.position.x, baby.transform.position.y + Time.deltaTime * movementMultiplier, baby.transform.position.z);
        //}
        //else if (currentHoldTime > 0)
        //{
        //    if (reset)
        //    {
        //        currentHoldTime = 0;
        //    }
        //    else
        //    {
        //        FailedSitUp();
        //    }
        //}

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

            if(checkpoint1Left && checkpoint1Right)
            {
                animator.SetInteger("Stage", 1);
            }

            if (checkpoint2Left && checkpoint2Right)
            {
                animator.SetInteger("Stage", 2);

                SucessfulSitUp();
            }

            // Check if the player has moved along the x axis
            if ((leftMove.x > inputXBuffer || leftMove.x < -inputXBuffer) || (rightMove.x > inputXBuffer || rightMove.x < -inputXBuffer))
            {
                Debug.Log("Fail");
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

        //moveDown = true;

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

        resetCoolDown = resetCoolDownTime;

        reset = true;

        ResetCheckPoints();

        currentHoldTime = 0;

        currentPatience--;

        UpdateSliders();

        if (currentPatience <= 0)
        {
            Lose();
        }
    }

    IEnumerator ResetAnimator()
    {
        yield return new WaitForSeconds(0.5f);

        animator.SetInteger("Stage", 0);
        animator.SetBool("Fail", false);
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

        //moveDown = true;

        sitUpCount++;

        UpdateSliders();

        ResetCheckPoints();

        if (sitUpCount >= sitUpGoal)
        {
            Win();
        }

        StartCoroutine("ResetAnimator");
    }

    void ResetCheckPoints()
    {
        checkpoint1Left = false;
        checkpoint1Right = false;
        checkpoint2Left = false;
        checkpoint2Right = false;
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
