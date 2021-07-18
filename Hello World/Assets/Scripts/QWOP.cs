using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QWOP : MonoBehaviour
{
    public GameObject instructionText;
    public GameObject lBText;
    public GameObject rTText;
    public GameObject rBText;
    public GameObject lTText;

    public CountDownBar countdown;

    private MiniGameInputs controls;

    private Animator anim;

    private bool isLeftMovement = true;
    private bool isRightMovement = false;
    private bool isFirstRight = false;
    private bool isFirstLeft = false;
    private bool canInput = true;

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

    void LeftMovement()
    {
        if (isLeftMovement == true)
        {
            anim.SetBool("wrongPressed", false);
            anim.SetInteger("leftMovement", 1);
            anim.SetInteger("rightMovement", 0);
            isLeftMovement = false;
            isFirstLeft = true;
            lBText.SetActive(false);
            rTText.SetActive(true);
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetInteger("leftMovement", 0);
            anim.SetInteger("rightMovement", 0);
        }
    }

    void LeftMovement1(float value)
    {
        if(canInput == true)
        {
            if (isFirstLeft == true)
            {
                anim.SetBool("wrongPressed", false);
                anim.SetInteger("leftMovement", 2);
                anim.SetInteger("rightMovement", 0);
                isFirstLeft = false;
                isRightMovement = true;
                rTText.SetActive(false);
                rBText.SetActive(true);
            }
            else if (value > 0.95f)
            {
                anim.SetBool("wrongPressed", true);
                anim.SetInteger("leftMovement", 0);
                anim.SetInteger("rightMovement", 0);
                isFirstLeft = false;
                isLeftMovement = true;
            }

            canInput = false;
        }  
    }

    void RightMovement()
    {
        if (isRightMovement == true)
        {
            anim.SetInteger("rightMovement", 1);
            anim.SetInteger("leftMovement", 0);
            anim.SetBool("wrongPressed", false);
            isRightMovement = false;
            isFirstRight = true;
            rBText.SetActive(false);
            lTText.SetActive(true);
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetInteger("rightMovement", 0);
            anim.SetInteger("leftMovement", 0);
        }
    }

    void RightMovement1(float value)
    {
        if(canInput == true)
        {
            if (isFirstRight == true && value > 0.95f)
            {
                anim.SetInteger("rightMovement", 2);
                anim.SetInteger("leftMovement", 0);
                anim.SetBool("wrongPressed", false);
                isFirstRight = false;
                isLeftMovement = true;
                lTText.SetActive(false);
                lBText.SetActive(true);
            }
            else if (value > 0.95f)
            {
                anim.SetBool("wrongPressed", true);
                anim.SetInteger("rightMovement", 0);
                anim.SetInteger("leftMovement", 0);
                isFirstRight = false;
                isRightMovement = true;
            }

            canInput = false;
        }
    }
}
