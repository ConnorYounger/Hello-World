using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;
    public ParentNarrative parent;
    public AnalogStickTweener ast;
    public ExerciseSoundEffectsManager soundEffectsManager;

    public GameObject liftButton;
    public GameObject swingButton;
    public GameObject pliftButton;
    public GameObject pswingButton;

    public GameObject parentText;
    public GameObject winMenu;

    private int leftSwingAmount = 0;
    private int rightSwingAmount = 0;

    private bool movement = true;
    public bool isLegUp = false;
    public bool win = false;
    public bool gameStarted = false;

    public float timerCheck = 0;
    public int timeLimit = 0;
    public float winTimer = 0;

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
        if (gameStarted == true)
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
                winTimer += Time.deltaTime;

                if (winTimer >= 5)
                {
                    winMenu.SetActive(true);
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

            //setting UI to show movement input action
            DisableText();
            swingButton.SetActive(true);
            pswingButton.SetActive(true);

            StartCoroutine("SwingAnimation");

        }
    }

    void LegDown()
    {
        if (gameStarted == true)
        {
            if (leftSwingAmount < 7)
            {
                anim.SetBool("legUp", false);
                anim.SetInteger("leftSwing", 0);
                anim.SetInteger("rightSwing", 0);
                leftSwingAmount = 0;
                rightSwingAmount = 0;
                timerCheck = 0;

                //resetting bools for swing movement restart
                movement = true;

                isLegUp = false;

                //playing fail sound and parent UI text
                parent.PlayFailNarrativeElement();
                soundEffectsManager.PlayFailSound();

                //setting UI to show movement input action
                DisableText();
                liftButton.SetActive(true);
                pliftButton.SetActive(true);
            }
        }
    }

    private IEnumerator SwingAnimation()
    {
        if(isLegUp == true)
        {
            if (movement == true && leftSwingAmount < 3)
            {
                ast.StopCoroutine("TiltRight");
                ast.StartCoroutine("TiltLeft");
                yield return new WaitForSeconds(4);
            }

            if (movement == false && rightSwingAmount <= 2)
            {
                ast.StopCoroutine("TiltLeft");
                ast.StartCoroutine("TiltRight");
                yield return new WaitForSeconds(4);
            }
        }
    }

    void SwingLeft()
    {
        if (gameStarted == true)
        {
            if (movement == true && timerCheck >= 1)
            {
                leftSwingAmount++;
                anim.SetInteger("leftSwing", leftSwingAmount);

                movement = false;
                timerCheck = 0;
                parent.NarrativeElement(parent.sucessDialougeTexts[leftSwingAmount - 1]);
                soundEffectsManager.PlaySucessSound();
                StartCoroutine("SwingAnimation");

                if(leftSwingAmount >= 3)
                {
                    DisableText();
                }
            }

            if (leftSwingAmount == 7)
            {
                DisableText();
                parentText.SetActive(false);
                parent.PlayWinNarrative();
                soundEffectsManager.PlayWinSound();
                gameStarted = false;
                win = true;
            }
        }

    }

    void SwingRight()
    {
        if (gameStarted == true)
        {
            if (movement == false && timerCheck >= 1)
            {
                rightSwingAmount++;
                anim.SetInteger("rightSwing", rightSwingAmount);
                movement = true;
                timerCheck = 0;
                soundEffectsManager.PlaySucessSound();
                StartCoroutine("SwingAnimation");
            }
        }
    }

    public void DisableText()
    {
        liftButton.SetActive(false);
        swingButton.SetActive(false);

        pliftButton.SetActive(false);
        pswingButton.SetActive(false);
    }
}
