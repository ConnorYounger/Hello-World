using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BabyBalancing : MonoBehaviour
{
    [Header("Balancing Variables")]
    public float maxBalanceValue = 90;
    public float maxTiltMultiplier = 1;
    [HideInInspector()] public float tiltMultiplier;
    public float playerRotateSpeed = 1;
    private float balanceValue = 0;
    public bool canTilt;

    public bool sitting = true;
    public float winAngle = 20;
    public float winAngleHoldTime = 5;
    private float currentHoldTime;
    private bool madeSucessSound;
    private bool canMakeSucessSound = true;
    private bool madeFailSound;
    private bool canMakeFailSound = true;

    [Header("UI")]
    public GameObject babyFellEGO;
    public GameObject winEGO;

    private MiniGameInputs controls;
    private Vector2 move;

    [Header("Baby Balancing Points")]
    public GameObject spine;
    public GameObject bottom;
    public float bottomRotateDifference = 3;

    public Animator animator;
    public AnalogStickTweener analogStickX;
    public AnalogStickTweener analogStickP;
    private bool left;

    [Space()]
    public ParentNarrative parent;
    public Exercise6BabyMovement exercise6Baby;
    public bool turn;
    public float resetWaitTime = 3;

    public ExerciseSoundEffectsManager soundManager;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.RightHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        if(analogStickX || analogStickP)
            StartCoroutine("UpDateAnimatedUI");

        canTilt = false;
    }

    public void ExerciseStart()
    {
        canTilt = true;
    }

    IEnumerator UpDateAnimatedUI()
    {
        yield return new WaitForSeconds(0.1f);

        if (canTilt)
        {
            if (left)
            {
                if (PlayerPrefs.GetString("ControlType") == "Xbox" && analogStickX)
                    analogStickX.StartCoroutine("TiltLeft");

                if (PlayerPrefs.GetString("ControlType") == "PS" && analogStickP)
                    analogStickP.StartCoroutine("TiltLeft");
            }
            else
            {
                if (PlayerPrefs.GetString("ControlType") == "Xbox" && analogStickX)
                    analogStickX.StartCoroutine("TiltRight");

                if (PlayerPrefs.GetString("ControlType") == "PS" && analogStickP)
                    analogStickP.StartCoroutine("TiltRight");
            }
        }

        yield return new WaitForSeconds(1);

        StartCoroutine("UpDateAnimatedUI");
    }

    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }

    void Update()
    {
        if (canTilt)
        {
            Tilt();
            PlayerMovement();
            BalanceWinCheck();
        }
        else if (exercise6Baby && turn)
        {
            ResetRotation();
        }
    }

    void BalanceWinCheck()
    {
        if (sitting && !exercise6Baby)
        {
            if(withinWinAngle())
            {
                if(currentHoldTime < winAngleHoldTime)
                {
                    currentHoldTime += Time.deltaTime;

                    if (canMakeSucessSound)
                    {
                        madeSucessSound = true;
                        canMakeSucessSound = false;

                        parent.NarrativeElement(parent.encouragingDialougeTexts[0]);
                    }
                }
                else
                {
                    AngelWin();
                }
            }
            else
            {
                currentHoldTime = 0;

                if (madeSucessSound)
                {
                    madeSucessSound = false;

                    StartCoroutine("ResetSucessSound");
                }
            }

            // fail text
            if (withinFailAngle())
            {
                if (canMakeFailSound)
                {
                    madeFailSound = true;
                    canMakeFailSound = false;

                    parent.PlayFailNarrativeElement();
                }
            }
            else
            {
                if (madeFailSound)
                {
                    madeFailSound = false;

                    StartCoroutine("ResetFailSound");
                }
            }
        }
    }

    IEnumerator ResetSucessSound()
    {
        yield return new WaitForSeconds(2);

        canMakeSucessSound = true;
    }

    IEnumerator ResetFailSound()
    {
        yield return new WaitForSeconds(2);

        canMakeFailSound = true;
    }

    void AngelWin()
    {
        canTilt = false;

        if (parent)
            parent.PlayWinNarrative();

        if (soundManager)
            soundManager.PlayWinSound();

        winEGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("MainMenuButton"));
        Debug.Log("Player Win");
    }

    bool withinWinAngle()
    {
        if (spine.transform.localRotation.y > 0 && spine.transform.localRotation.y < CalculateRotationValue(winAngle) || spine.transform.localRotation.y < 0 && spine.transform.localRotation.y > -CalculateRotationValue(winAngle))
            return true;
        else
            return false;
    }

    bool withinFailAngle()
    {
        if (spine.transform.localRotation.y > 0 && spine.transform.localRotation.y < CalculateRotationValue(maxBalanceValue - (2 *winAngle)) || spine.transform.localRotation.y < 0 && spine.transform.localRotation.y > -CalculateRotationValue(maxBalanceValue - (2 * winAngle)))
            return false;
        else
            return true;
    }

    void PlayerMovement()
    {
        int dir = 1;
        if (sitting)
            dir = -1;
        else
            dir = 1;

        //Vector3 rotation = new Vector3(transform.localRotation.x, transform.localRotation.y, move.x);
        Vector3 rotation = new Vector3(spine.transform.localRotation.x, move.x * dir, spine.transform.localRotation.z);
        //transform.Rotate(rotation * Time.deltaTime * playerRotateSpeed);
        spine.transform.Rotate(rotation * Time.deltaTime * playerRotateSpeed);
    }

    void Tilt()
    {
        //Debug.Log(move);

        if(tiltMultiplier < maxTiltMultiplier)
        {
            tiltMultiplier += tiltMultiplier/100 + 0.01f * Time.deltaTime;
        }
        else if (tiltMultiplier > maxTiltMultiplier)
        {
            tiltMultiplier = maxTiltMultiplier;
        }

        if (spine.transform.localRotation.y > 0 && spine.transform.localRotation.y < CalculateMaxBalanceValue())
        {
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), transform.localRotation.w);
            spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, spine.transform.localRotation.y + (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), spine.transform.localRotation.z, spine.transform.localRotation.w);
            //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, bottom.transform.localRotation.y + CalculateBottomDifference(tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), bottom.transform.localRotation.z, bottom.transform.localRotation.w);
            left = false;
        }
        else if (spine.transform.localRotation.y < 0 && spine.transform.localRotation.y > -CalculateMaxBalanceValue())
        {
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), transform.localRotation.w);
            spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, spine.transform.localRotation.y - (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), spine.transform.localRotation.z, spine.transform.localRotation.w);
            //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, bottom.transform.localRotation.y - CalculateBottomDifference(tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), bottom.transform.localRotation.z, bottom.transform.localRotation.w);
            left = true;
        }
        else if (spine.transform.localRotation.y == 0)
        {
            int rand = Random.Range(0, 2);
            balanceValue = rand > 0 ? -0.001f : 0.001f;

            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, CalculateRotationValue(balanceValue), transform.localRotation.w);
            spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, CalculateRotationValue(balanceValue), spine.transform.localRotation.z, spine.transform.localRotation.w);
            //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, CalculateBottomDifference(CalculateRotationValue(balanceValue)), bottom.transform.localRotation.z, bottom.transform.localRotation.w);
        }

        if (!sitting)
        {
            if (spine.transform.localRotation.y > 0 && spine.transform.localRotation.y >= CalculateMaxBalanceValue())
            {
                BabyFallOver(true);
            }
            else if (spine.transform.localRotation.y < 0 && spine.transform.localRotation.y <= -CalculateMaxBalanceValue())
            {
                BabyFallOver(false);
            }
        }
    }

    void ResetRotation()
    {
        if (spine.transform.localRotation.y > 0 && spine.transform.localRotation.y < CalculateMaxBalanceValue())
        {
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), transform.localRotation.w);
            spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, spine.transform.localRotation.y - (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), spine.transform.localRotation.z, spine.transform.localRotation.w);
            //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, bottom.transform.localRotation.y + CalculateBottomDifference(tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), bottom.transform.localRotation.z, bottom.transform.localRotation.w);
            left = false;
        }
        else if (spine.transform.localRotation.y < 0 && spine.transform.localRotation.y > -CalculateMaxBalanceValue())
        {
            //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), transform.localRotation.w);
            spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, spine.transform.localRotation.y + (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), spine.transform.localRotation.z, spine.transform.localRotation.w);
            //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, bottom.transform.localRotation.y - CalculateBottomDifference(tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), bottom.transform.localRotation.z, bottom.transform.localRotation.w);
            left = true;
        }
    }

    public IEnumerator SetRotationToDefult()
    {
        yield return new WaitForSeconds(0);
        balanceValue = 0;
        spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, CalculateRotationValue(balanceValue), spine.transform.localRotation.z, spine.transform.localRotation.w);

    }

    void BabyFallOver(bool value)
    {
        Debug.Log("BabyFell");

        StartCoroutine("BabyFallReset", value);
    }

    IEnumerator BabyFallReset(bool value)
    {
        canTilt = false;

        if (value)
            animator.SetBool("fallLeft", true);

        else
            animator.SetBool("fallRight", true);

        exercise6Baby.StopCoroutine("ReseMovementCoolDown");
        exercise6Baby.canMove = false;

        if (parent)
            parent.PlayFailNarrativeElement();

        if (soundManager)
            soundManager.PlayFailSound();

        yield return new WaitForSeconds(1f);

        int rand = Random.Range(0, 2);
        balanceValue = rand > 0 ? -0.001f : 0.001f;
        spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, CalculateRotationValue(balanceValue), spine.transform.localRotation.z, spine.transform.localRotation.w);

        animator.SetBool("fallLeft", false);
        animator.SetBool("fallRight", false);

        yield return new WaitForSeconds(resetWaitTime);

        Restart();
        exercise6Baby.canMove = true;
    }

    float CalculateTiltSmoothValue()
    {
        float value = 0;
        //value = 1 + Mathf.Abs(transform.localRotation.z) / CalculateMaxBalanceValue();
        if(sitting)
            value = 1 + Mathf.Abs(spine.transform.localRotation.y) / CalculateMaxBalanceValue();
        else
            value = 1 + Mathf.Abs(spine.transform.localRotation.x) / CalculateMaxBalanceValue();

        float tiltSmoothValue = Mathf.Pow(value, 3);
        return tiltSmoothValue;
    }

    public float CalculateMaxBalanceValue()
    {
        return (maxBalanceValue / 360) * 3;
    }

    public float CalculateRotationValue(float value)
    {
        return (value / 360) * 3;
    }

    float CalculateBottomDifference(float spine)
    {
        return spine / bottomRotateDifference;
    }

    public void BabyFell()
    {
        canTilt = false;

        if (parent)
            parent.PlayFailNarrativeElement();

        if (soundManager)
            soundManager.PlayLoseSound();

        if (babyFellEGO)
            babyFellEGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(GameObject.Find("RestartButton"));
    }

    public void Restart()
    {
        Debug.Log("Restart");

        //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
        spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, 0, spine.transform.localRotation.z, spine.transform.localRotation.w);
        //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, 0, bottom.transform.localRotation.z, bottom.transform.localRotation.w);
        canTilt = true;
        tiltMultiplier = 0;

        if(babyFellEGO)
            babyFellEGO.SetActive(false);

        if (exercise6Baby)
            exercise6Baby.BabyFellUpdateUI();
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
