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
    private int successCount = 0;

    private bool leftMovement = true;
    private bool rightMovement = false;
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

                //resetting bools for swing movement restart
                leftMovement = true;
                rightMovement = false;

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
        while (isLegUp == true)
        {
            if(leftMovement == true && leftSwingAmount < 3)
            {
                ast.StopCoroutine("TiltRight");
                ast.StartCoroutine("TiltLeft");
                yield return new WaitForSeconds(4);
            }

            if(rightMovement == true && leftSwingAmount < 3)
            {
                ast.StopCoroutine("TiltLeft");
                ast.StartCoroutine("TiltRight");
                yield return new WaitForSeconds(4);
            }

            if(leftSwingAmount == 3)
            {
                ast.StopAllCoroutines();
            }
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
                parent.NarrativeElement(parent.sucessDialougeTexts[leftSwingAmount - 1]);
                soundEffectsManager.PlaySucessSound();
                StartCoroutine("SwingAnimation");
            }

            if (leftSwingAmount == 7)
            {
                DisableText();
                parentText.SetActive(false);
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
