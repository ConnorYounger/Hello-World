using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise6BabyMovement : MonoBehaviour
{
    public bool simpleMovement = true;
    public float movementSpeed = 1;
    public float stepTime = 0.16f;
    private float currentStepTime;
    public float stepCoolDownTime = 1;

    public Animator animator;

    private MiniGameInputs controls;
    private Vector2 move;
    private Vector2 tilt;

    private bool canMove = true;
    private int dir;

    private void Awake()
    {
        controls = new MiniGameInputs();

        controls.HoldingObjects.LeftHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();

        controls.HoldingObjects.LeftHandGrab.performed += ctx => PlayerMovement(ctx.ReadValue<float>(), true);

        controls.HoldingObjects.RightHandGrab.performed += ctx => PlayerMovement(ctx.ReadValue<float>(), false);
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
    }

    void PlayerMovement(float value, bool leftFoot)
    {
        if(canMove && value >= 1 && !simpleMovement)
        {
            if (leftFoot)
            {
                if (animator.GetInteger("babyFoot") == 0 || animator.GetInteger("babyFoot") == 3)
                {
                    animator.SetInteger("babyFoot", 2);
                    dir = -1;
                }
                else
                {
                    animator.SetInteger("babyFoot", 0);
                    dir = 1;
                }
            }
            else
            {
                if (animator.GetInteger("babyFoot") == 1 || animator.GetInteger("babyFoot") == 2)
                {
                    animator.SetInteger("babyFoot", 3);
                    dir = -1;
                }
                else
                {
                    animator.SetInteger("babyFoot", 1);
                    dir = 1;
                }
            }

            //animator.SetBool("babyLeftFoot", leftFoot);
            Debug.Log("babyLeftFoot");

            currentStepTime = stepTime;

            canMove = false;

            Invoke("ReseMovementCoolDown", stepCoolDownTime);
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

    void ReseMovementCoolDown()
    {
        canMove = true;
    }

    void ComplexPlayerMovement()
    {
        //Movement


        // Rotation
        Vector3 rotation = new Vector3(transform.rotation.x, move.x, transform.rotation.z);
        transform.Rotate(rotation * Time.deltaTime * 100);
    }

    void SimplePlayerMovement()
    {
        transform.position = transform.position + (transform.forward * move.y * Time.deltaTime * movementSpeed);

        Vector3 rotation = new Vector3(transform.rotation.x, move.x, transform.rotation.z);
        transform.Rotate(rotation * Time.deltaTime * 100);
    }
}
