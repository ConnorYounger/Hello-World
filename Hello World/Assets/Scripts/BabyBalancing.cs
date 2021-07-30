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
    private float tiltMultiplier;
    public float playerRotateSpeed = 1;
    private float balanceValue = 0;
    public bool canTilt;

    public bool sitting = true;
    public float winAngle = 20;
    public float winAngleHoldTime = 5;
    private float currentHoldTime;

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
    public AnalogStickTweener analogStick;
    private bool left;

    [Space()]
    public ParentNarrative parent;
    public Exercise6BabyMovement exercise6Baby;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.RightHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
    }

    private void Start()
    {
        if(analogStick)
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

        if (left)
            analogStick.StartCoroutine("TiltLeft");
        else
            analogStick.StartCoroutine("TiltRight");

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
                }
                else
                {
                    AngelWin();
                }
            }
            else
            {
                currentHoldTime = 0;
            }
        }
    }

    void AngelWin()
    {
        canTilt = false;

        if (parent)
            parent.PlayWinNarrative();

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
                BabyFallOver();
            }
            else if (spine.transform.localRotation.y < 0 && spine.transform.localRotation.y <= -CalculateMaxBalanceValue())
            {
                BabyFallOver();
            }
        }
    }

    void BabyFallOver()
    {
        Debug.Log("BabyFell");

        StartCoroutine("BabyFallReset");
    }

    IEnumerator BabyFallReset()
    {
        canTilt = false;
        // play get up animation
        exercise6Baby.StopCoroutine("ReseMovementCoolDown");
        exercise6Baby.canMove = false;

        if (parent)
            parent.PlayFailNarrativeElement();

        yield return new WaitForSeconds(1);

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
            parent.PlayLoseNarrative();

        babyFellEGO.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("RestartButton"));
    }

    public void Restart()
    {
        //transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
        spine.transform.localRotation = new Quaternion(spine.transform.localRotation.x, 0, spine.transform.localRotation.z, spine.transform.localRotation.w);
        //bottom.transform.localRotation = new Quaternion(bottom.transform.localRotation.x, 0, bottom.transform.localRotation.z, bottom.transform.localRotation.w);
        canTilt = true;
        tiltMultiplier = 0;

        babyFellEGO.SetActive(false);
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
