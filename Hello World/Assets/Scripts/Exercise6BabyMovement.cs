using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Exercise6BabyMovement : MonoBehaviour
{
    public bool simpleMovement = false;
    public float movementSpeed = 1;
    public float stepTime = 0.16f;
    private float currentStepTime;
    public float stepCoolDownTime = 1;

    public Animator animator;

    public BabyBalancing babyBalancing;
    public ParentNarrative parent;
    public Transform winZone;
    public float winDistamce = 2;

    private MiniGameInputs controls;
    private Vector2 move;
    private Vector2 tilt;

    public bool canMove;
    private bool gameEnd;
    private int dir;

    [Header("UI Elements")]
    public GameObject winUI;

    public GameObject[] leftTriggers;
    public GameObject[] rightTriggers;
    public AnalogStickTweener analogStick;

    public ExerciseSoundEffectsManager soundManager;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.LeftHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();

        controls.HoldingObjects.LeftHandGrab.performed += ctx => PlayerMovement(ctx.ReadValue<float>(), true);

        controls.HoldingObjects.RightHandGrab.performed += ctx => PlayerMovement(ctx.ReadValue<float>(), false);
    }

    private void Start()
    {
        canMove = false;
    }

    public void StartExercise()
    {
        canMove = true;
        UpdateControllsUI(false);
    }

    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }

    private void Update()
    {
        if (simpleMovement)
            SimplePlayerMovement();
        else
            ComplexPlayerMovement();

        MoveForward();
        CheckForWinZone();
    }

    void CheckForWinZone()
    {
        if(Vector3.Distance(transform.position, winZone.position) < winDistamce && !gameEnd)
        {
            Win();
        }
    }

    void PlayerMovement(float value, bool leftFoot)
    {
        if(canMove && value >= 1 && !simpleMovement && !gameEnd)
        {
            if (leftFoot)
            {
                if (animator.GetInteger("babyFoot") == 0 || animator.GetInteger("babyFoot") == 3)
                {
                    animator.SetInteger("babyFoot", 2);
                    dir = -1;

                    UpdateControllsUI(true);
                }
                else
                {
                    animator.SetInteger("babyFoot", 0);
                    dir = 1;

                    UpdateControllsUI(false);
                }
            }
            else
            {
                if (animator.GetInteger("babyFoot") == 1 || animator.GetInteger("babyFoot") == 2)
                {
                    animator.SetInteger("babyFoot", 3);
                    dir = -1;

                    UpdateControllsUI(false);
                }
                else
                {
                    animator.SetInteger("babyFoot", 1);
                    dir = 1;

                    UpdateControllsUI(true);
                }
            }

            //animator.SetBool("babyLeftFoot", leftFoot);
            Debug.Log("babyLeftFoot");

            currentStepTime = stepTime;

            canMove = false;

            StartCoroutine("ReseMovementCoolDown");
        }
    }

    public void BabyFellUpdateUI()
    {
        if (animator.GetInteger("babyFoot") == 0 || animator.GetInteger("babyFoot") == 3)
        {
            UpdateControllsUI(false);
        }
        else
        {
            UpdateControllsUI(true);
        }
    }

    public void UpdateControllsUI(bool left)
    {
        bool right = !left;

        Debug.Log("Left: " + left + " , Right: " + right);

        for(int i = 0; i < leftTriggers.Length; i++)
        {
            leftTriggers[i].SetActive(left);
            rightTriggers[i].SetActive(right);
        }
    }

    void MoveForward()
    {
        if(currentStepTime > 0)
        {
            currentStepTime -= Time.deltaTime;

            transform.position = transform.position + (transform.forward * Time.deltaTime * movementSpeed) * dir;
        }
    }

    IEnumerator ReseMovementCoolDown()
    {
        yield return new WaitForSeconds(stepCoolDownTime);

        canMove = true;
    }

    void ComplexPlayerMovement()
    {
        // Rotation
        if (currentStepTime > 0)
        {
            Vector3 rotation = new Vector3(transform.rotation.x, move.x, transform.rotation.z);
            transform.Rotate(rotation * Time.deltaTime * 100);
        }
    }

    void SimplePlayerMovement()
    {
        transform.position = transform.position + (transform.forward * move.y * Time.deltaTime * movementSpeed);

        Vector3 rotation = new Vector3(transform.rotation.x, move.x, transform.rotation.z);
        transform.Rotate(rotation * Time.deltaTime * 100);
    }

    public void Exersise6Win()
    {
        Debug.Log("You did it!");
    }

    void Win()
    {
        Debug.Log("Player Win");

        gameEnd = true;

        if (babyBalancing)
            babyBalancing.canTilt = false;

        if(parent)
            parent.PlayWinNarrative();

        if (soundManager)
            soundManager.PlayWinSound();

        if (winUI)
        {
            winUI.SetActive(true);

            EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuButton"));
        }
    }

    public void Lose()
    {
        gameEnd = true;

        if (parent)
            parent.PlayLoseNarrative();

        if (soundManager)
            soundManager.PlayLoseSound();
    }
}
