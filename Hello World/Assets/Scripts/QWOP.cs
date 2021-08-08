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
    public ExerciseSoundEffectsManager soundEffectManager;
    public WinWithToy check;

    private MiniGameInputs controls;
    private Animator anim;

    private int successCount = 0;
    public int instructionCount = 0;
    public int movementCount = 0;

    private bool canInput = true;
    public bool instructionText = false;
    public bool gameStarted = false;

    private void Awake()
    {
        //setting up animations and inputs
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
    }

    void SetInputActions()
    {
        //setting inputs to action functions
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
            if(check.gameWon == false)
            {
                if (movementCount == 0)
                {
                    //actioning movement animations with an integer
                    anim.SetInteger("rightMovement", 0);
                    anim.SetInteger("leftMovement", 1);

                    //comments in functions
                    InstructionText();
                    TextCheck();

                    //increasing integers for switch in above functions
                    instructionCount++;
                    movementCount++;
                }
                else
                {
                    //comments in functions
                    WrongPressed();
                    FailTextCheck();
                }
            }
        }
    }

    void LeftMovement1(float value)
    {
        if (gameStarted == true && canInput == true)
        {
            if(check.gameWon == false)
            {
                if (movementCount == 1)
                {
                    //actioning movement animations with an integer
                    anim.SetInteger("leftMovement", 2);

                    //comments in function, also increasing integer for below function
                    TextCheck();
                    movementCount++;

                    //playing success sounds for correct movement
                    soundEffectManager.PlaySucessSound();
                }
                else if (value > 0.95f)
                {
                    //comments in functions
                    WrongPressed();
                    FailTextCheck();
                }

                canInput = false;
            }
        }
    }

    void RightMovement()
    {
        if (gameStarted == true)
        {
            if(check.gameWon == false)
            {
                if (movementCount == 2)
                {
                    //actioning movement animations with an integer
                    anim.SetInteger("leftMovement", 0);
                    anim.SetInteger("rightMovement", 1);

                    //comments in function, also increasing integer for below function
                    TextCheck();
                    movementCount++;
                }
                else
                {
                    //comments in functions
                    WrongPressed();
                    FailTextCheck();
                }
            }
        }
    }

    void RightMovement1(float value)
    {
        if (gameStarted == true && canInput == true)
        {
            if(check.gameWon == false)
            {
                if (movementCount == 3)
                {
                    //actioning movement animations with an integer
                    anim.SetInteger("rightMovement", 2);

                    //comments in function, also reseting integer for below function
                    TextCheck();
                    movementCount = 0;

                    //playing success sounds for correct movement, and the parent narrative text
                    soundEffectManager.PlaySucessSound();
                    successCount++;
                    parent.NarrativeElement(parent.sucessDialougeTexts[successCount - 1]);
                }
                else if (value > 0.95f)
                {
                    //comments in functions
                    WrongPressed();
                    FailTextCheck();
                }

                canInput = false;
            }
        }
    }

    public void WrongPressed()
    {
        //actioning fail animation with bool
        anim.SetBool("wrongPressed", true);
        anim.SetInteger("leftMovement", 0);
        anim.SetInteger("rightMovement", 0);

        //playing fail text and sounds
        parent.PlayFailNarrativeElement();
        soundEffectManager.PlayFailSound();

        //reseting instruction text to show UI
        instructionText = false;
        instructionCount = 0;
        StartCoroutine("WrongReset");
    }

    public IEnumerator WrongReset()
    {
        //using IEnumerator to wait before setting bool to false
        yield return new WaitForSeconds(1);
        anim.SetBool("wrongPressed", false);
    }

    public void DisableText()
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

    public void TextCheck()
    {
        DisableText();

        if (instructionText == false)
        {
            //using a switch to show correct UI buttons by tracking movementCount and activating buttons
            switch (movementCount)
            {
                case 0:
                    prTText.SetActive(true);
                    rTText.SetActive(true);
                    break;
                case 1:
                    prBText.SetActive(true);
                    rBText.SetActive(true);
                    break;
                case 2:
                    plTText.SetActive(true);
                    lTText.SetActive(true);
                    break;
                case 3:
                    plBText.SetActive(true);
                    lBText.SetActive(true);
                    break;
            }
        }
    }

    public void FailTextCheck()
    {
        DisableText();

        //using a switch to show correct UI buttons by tracking movementCount and activating buttons
        switch (movementCount)
        {
            case 0:
                plBText.SetActive(true);
                lBText.SetActive(true);
                break;
            case 1:
                prTText.SetActive(true);
                rTText.SetActive(true);
                break;
            case 2:
                prBText.SetActive(true);
                rBText.SetActive(true);
                break;
            case 3:
                plTText.SetActive(true);
                lTText.SetActive(true);
                break;
        }
    }

    public void InstructionText()
    {
        //checking instructionCount increased in LeftMovement to set bool after 3 correct movements
        if (instructionCount == 3)
        {
            instructionText = true;
        }
        //checking bool to disable instruction text
        if (instructionText == true)
        {
            DisableText();
        }
    }

    public void ReturnToMain(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
