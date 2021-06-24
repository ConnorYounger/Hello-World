using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BabyBalancing : MonoBehaviour
{
    [Header("Balancing Variables")]
    public float maxBalanceValue = 90;
    public float tiltMultiplier = 1;
    public float playerRotateSpeed = 1;
    private float balanceValue = 0;
    private bool canTilt = true;

    [Header("UI")]
    public GameObject babyFellEGO;

    private MiniGameInputs controls;
    private Vector2 move;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.RightHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
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
        }
    }

    void PlayerMovement()
    {
        //Vector3 rotation = new Vector3(transform.rotation.x, transform.rotation.y, move.x);
        Vector3 rotation = new Vector3(transform.localRotation.x, transform.localRotation.y, move.x);
        //transform.Rotate(rotation * Time.deltaTime * playerRotateSpeed);
        transform.Rotate(rotation * Time.deltaTime * playerRotateSpeed);
    }

    void Tilt()
    {
        Debug.Log(move);

        if (transform.localRotation.z > 0 && transform.localRotation.z < CalculateMaxBalanceValue())
        {
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), transform.rotation.w);
            transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + (tiltMultiplier * Time.deltaTime * CalculateTiltSmoothValue()), transform.localRotation.w);
        }
        else if (transform.localRotation.z < 0 && transform.localRotation.z > -CalculateMaxBalanceValue())
        {
            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), transform.rotation.w);
            transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - (tiltMultiplier * Time.deltaTime) * CalculateTiltSmoothValue(), transform.localRotation.w);
        }
        else if (transform.localRotation.z == 0)
        {
            int rand = Random.Range(0, 2);
            balanceValue = rand > 0 ? -0.001f : 0.001f;

            //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, CalculateRotationValue(balanceValue), transform.rotation.w);
            transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, CalculateRotationValue(balanceValue), transform.localRotation.w);
        }
    }

    float CalculateTiltSmoothValue()
    {
        float value = 0;
        //value = 1 + Mathf.Abs(transform.rotation.z) / CalculateMaxBalanceValue();
        value = 1 + Mathf.Abs(transform.localRotation.z) / CalculateMaxBalanceValue();

        float tiltSmoothValue = Mathf.Pow(value, 3);
        return tiltSmoothValue;
    }

    public float CalculateMaxBalanceValue()
    {
        return (maxBalanceValue / 360) * 3;
    }

    float CalculateRotationValue(float value)
    {
        return (value / 360) * 3;
    }

    public void BabyFell()
    {
        canTilt = false;

        babyFellEGO.SetActive(true);
    }

    public void Restart()
    {
        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        transform.localRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, 0, transform.localRotation.w);
        canTilt = true;

        babyFellEGO.SetActive(false);
    }
}
