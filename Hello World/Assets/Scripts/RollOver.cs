using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;
    public ParentNarrative parent;
    public AnalogStickTweener call;
    public ExerciseSoundEffectsManager soundEffectsManager;

    public GameObject liftButton;
    public GameObject swingButton;
    public GameObject pliftButton;
    public GameObject pswingButton;

    public GameObject parentText;
    public GameObject winText;
    public GameObject activate;
    
    private int leftSwingAmount = 0;
    private int rightSwingAmount = 0;
    private int successCount = 0;

    private bool leftMovement = true;
    private bool rightMovement = false;
    public bool isLegUp = false;
    public bool win = false;
    public bool gameStarted = false;

    public float timerCheck = 0;
    public int timeLimit = 0;
    public float pauseTimer = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
    }


    private void OnEnable()
    {
        controls.RollOver.Enable();
    }

    private void OnDisable()
    {
        controls.RollOver.Disable();
    }

    void SetInputActions()
    {
        controls.RollOver.SwingLeft.performed += ctx => SwingLeft();
        controls.RollOver.SwingRight.performed += ctx => SwingRight();

        controls.RollOver.LegMovement.performed += ctx => LegUp(ctx.ReadValue<float>());
        controls.RollOver.LegMovement.canceled += ctx => LegDown();
    }

    public void ReturnToMain(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Update()
    {
        if(gameStarted == true)
        {
            if (isLegUp == true)
            {
                timerCheck += Time.deltaTime;
            }

            if (timerCheck >= timeLimit && leftSwingAmount < 7)
            {
                LegDown();
            }

            if (win == true)
            {
                pauseTimer += Time.deltaTime;

                if (pauseTimer >= 5)
                {
                    activate.SetActive(true);
                }
            }
        }
    }

    public void StartExercise()
    {
        gameStarted = true;
    }

    void LegUp(float value)
    {
        if (gameStarted == true)
        {
            anim.SetBool("legUp", true);
            isLegUp = true;
            liftButton.SetActive(false);
            swingButton.SetActive(true);

            pliftButton.SetActive(false);
            pswingButton.SetActive(true);
            StartCoroutine("SwingAnimation");
        }
    }

    void LegDown()
    {
        if(gameStarted == true)
        {
            if (leftSwingAmount < 7)
            {
                anim.SetBool("legUp", false);
                anim.SetInteger("leftSwing", 0);
                anim.SetInteger("rightSwing", 0);
                leftSwingAmount = 0;
                rightSwingAmount = 0;
                timerCheck = 0;

                isLegUp = false;
                parent.PlayFailNarrativeElement();
                soundEffectsManager.PlayFailSound();

                liftButton.SetActive(true);
                pliftButton.SetActive(true);

                swingButton.SetActive(false);
                pswingButton.SetActive(false);
            }
        }
    }

    private IEnumerator SwingAnimation()
    {
        while (isLegUp == true)
        {
            call.StartCoroutine("TiltHorizontal");
            yield return new WaitForSeconds(4);
        }
    }

    void SwingLeft()
    {
        if(gameStarted == true)
        {
            if (leftMovement == true && timerCheck >= 1)
            {
                leftSwingAmount++;
                successCount++;
                anim.SetInteger("leftSwing", leftSwingAmount);
                leftMovement = false;
                rightMovement = true;
                timerCheck = 0;
                parent.NarrativeElement(parent.sucessDialougeTexts[successCount - 1]);
                soundEffectsManager.PlaySucessSound();
            }

            if (leftSwingAmount == 7)
            {
                liftButton.SetActive(false);
                swingButton.SetActive(false);

                pliftButton.SetActive(false);
                pswingButton.SetActive(false);

                parentText.SetActive(false);
                winText.SetActive(true);
                parent.PlayWinNarrative();
                soundEffectsManager.PlayWinSound();
                win = true;
            }
        }
        
    }

    void SwingRight()
    {
        if (gameStarted == true)
        {
            if (rightMovement == true && timerCheck >= 1)
            {
                rightSwingAmount++;
                anim.SetInteger("rightSwing", rightSwingAmount);
                rightMovement = false;
                leftMovement = true;
                timerCheck = 0;
                soundEffectsManager.PlaySucessSound();
            }
        }
    }
}
