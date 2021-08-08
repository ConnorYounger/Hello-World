using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class QWOP : MonoBehaviour
{
    public GameObject lBText;
    public GameObject rTText;
    public GameObject rBText;
    public GameObject lTText;

    public GameObject plBText;
    public GameObject prTText;
    public GameObject prBText;
    public GameObject plTText;

    public ParentNarrative parent;
    public CountDownBar countdown;
    public ExerciseSoundEffectsManager soundEffectManager;
    public WinWithToy check;

    private MiniGameInputs controls;
    private Animator anim;

    private int successCount = 0;
    public int instructionCount = 0;

    private bool isLeftMovement = true;
    private bool isRightMovement = false;
    private bool isFirstRight = false;
    private bool isFirstLeft = false;
    private bool canInput = true;
    public bool instructionText = false;
    public bool gameStarted = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
    }

    void SetInputActions()
    {
        controls.QWOP.LeftMovement1.performed += ctx => LeftMovement();
        controls.QWOP.RightMovement1.performed += ctx => RightMovement();

        controls.QWOP.LeftMovement2.performed += ctx => LeftMovement1(ctx.ReadValue<float>());
        controls.QWOP.LeftMovement2.canceled += ctx => canInput = true;
        controls.QWOP.RightMovement2.performed += ctx => RightMovement1(ctx.ReadValue<float>());
        controls.QWOP.RightMovement2.canceled += ctx => canInput = true;
    }

    private void OnEnable()
    {
        controls.QWOP.Enable();
    }

    private void OnDisable()
    {
        controls.QWOP.Disable();
    }

    public void StartExercise()
    {
        gameStarted = true;
    }

    void LeftMovement()
    {
        if (gameStarted == true)
        {
            if (instructionCount == 3)
            {
                instructionText = true;
            }

            if (instructionText == true)
            {
                lBText.SetActive(false);
                rTText.SetActive(false);
                rBText.SetActive(false);
                lTText.SetActive(false);

                plBText.SetActive(false);
                prTText.SetActive(false);
                prBText.SetActive(false);
                plTText.SetActive(false);
            }

            if (isLeftMovement == true && check.gameWon == false)
            {
                anim.SetBool("wrongPressed", false);
                anim.SetInteger("leftMovement", 1);
                anim.SetInteger("rightMovement", 0);
                isLeftMovement = false;
                isFirstLeft = true;

                if (instructionText == false)
                {
                    plBText.SetActive(false);
                    prTText.SetActive(true);
                    lBText.SetActive(false);
                    rTText.SetActive(true);
                    instructionCount++;
                }
            }
            else
            {
                WrongPressed();
                lTText.SetActive(false);
                lBText.SetActive(true);
                plTText.SetActive(false);
                plBText.SetActive(true);
            }
        }
    }

    void LeftMovement1(float value)
    {
        if (gameStarted == true)
        {
            if (canInput == true)
            {
                if (isFirstLeft == true && check.gameWon == false)
                {
                    anim.SetBool("wrongPressed", false);
                    anim.SetInteger("leftMovement", 2);
                    anim.SetInteger("rightMovement", 0);
                    isFirstLeft = false;
                    isRightMovement = true;
                    soundEffectManager.PlaySucessSound();

                    if (instructionText == false)
                    {
                        prTText.SetActive(false);
                        prBText.SetActive(true);

                        rTText.SetActive(false);
                        rBText.SetActive(true);
                    }
                }
                else if (value > 0.95f)
                {
                    WrongPressed();
                    isFirstLeft = false;
                    isLeftMovement = true;
                    plBText.SetActive(false);
                    prTText.SetActive(true);
                    lBText.SetActive(false);
                    rTText.SetActive(true);
                }

                canInput = false;
            }
        }
    }

    void RightMovement()
    {
        if (gameStarted == true)
        {
            if (isRightMovement == true && check.gameWon == false)
            {
                anim.SetInteger("rightMovement", 1);
                anim.SetInteger("leftMovement", 0);
                anim.SetBool("wrongPressed", false);
                isRightMovement = false;
                isFirstRight = true;

                if (instructionText == false)
                {
                    prBText.SetActive(false);
                    plTText.SetActive(true);

                    rBText.SetActive(false);
                    lTText.SetActive(true);
                }
            }
            else
            {
                WrongPressed();
                prTText.SetActive(false);
                prBText.SetActive(true);
                rTText.SetActive(false);
                rBText.SetActive(true);
            }
        } 
    }

    void RightMovement1(float value)
    {
        if (gameStarted == true)
        {
            if (canInput == true)
            {
                if (isFirstRight == true && check.gameWon == false)
                {
                    anim.SetInteger("rightMovement", 2);
                    anim.SetInteger("leftMovement", 0);
                    anim.SetBool("wrongPressed", false);
                    isFirstRight = false;
                    isLeftMovement = true;
                    successCount++;
                    parent.NarrativeElement(parent.sucessDialougeTexts[successCount - 1]);
                    soundEffectManager.PlaySucessSound();

                    if (instructionText == false)
                    {
                        plTText.SetActive(false);
                        plBText.SetActive(true);

                        lTText.SetActive(false);
                        lBText.SetActive(true);
                    }
                }
                else if (value > 0.95f)
                {
                    WrongPressed();
                    isFirstRight = false;
                    isRightMovement = true;
                    prBText.SetActive(false);
                    plTText.SetActive(true);
                    rBText.SetActive(false);
                    lTText.SetActive(true);
                }

                canInput = false;
            }
        }  
    }

    public void WrongPressed()
    {
        anim.SetBool("wrongPressed", true);
        anim.SetInteger("leftMovement", 0);
        anim.SetInteger("rightMovement", 0);
        parent.PlayFailNarrativeElement();
        soundEffectManager.PlayFailSound();
        instructionText = false;
        instructionCount = 0;
    }

    public void ReturnToMain(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
