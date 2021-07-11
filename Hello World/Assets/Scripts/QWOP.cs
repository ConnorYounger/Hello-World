using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QWOP : MonoBehaviour
{
    public GameObject instructionText;
    public GameObject qText;
    public GameObject wText;
    public GameObject oText;
    public GameObject pText;

    public WinWithToy winWithToy;
    public CountDownBar countdown;

    private MiniGameInputs controls;

    private Animator anim;

    //add bools for each limb to stop from moving backwards too much. 

    private char lastPressed;
    private bool isLeftMovement = true;
    private bool isRightMovement = false;
    private bool isFirstRight = false;
    private bool isFirstLeft = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
    }

    void SetInputActions()
    {
        controls.QWOP.LeftMovement1.performed += ctx => LeftMovement();
        controls.QWOP.LeftMovement2.performed += ctx => LeftMovement1();
        controls.QWOP.RightMovement1.performed += ctx => RightMovement();
        controls.QWOP.RightMovement2.performed += ctx => RightMovement1();
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
        }
        //else
        //{
        //    anim.SetBool("wrongPressed", true);
        //    anim.SetInteger("leftMovement", 0);
        //    anim.SetInteger("rightMovement", 0);
        //}
    }

    void LeftMovement1()
    {
        if(isFirstLeft == true)
        {
            anim.SetBool("wrongPressed", false);
            anim.SetInteger("leftMovement", 2);
            anim.SetInteger("rightMovement", 0);
            isFirstLeft = false;
            isRightMovement = true;
        }
        //else
        //{
        //    anim.SetBool("wrongPressed", true);
        //    anim.SetInteger("leftMovement", 0);
        //    anim.SetInteger("rightMovement", 0);
        //    isFirstLeft = false;
        //    isLeftMovement = true;
        //}
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
        }
        //else
        //{
        //    anim.SetBool("wrongPressed", true);
        //    anim.SetInteger("rightMovement", 0);
        //    anim.SetInteger("leftMovement", 0);
        //}
    }

    void RightMovement1()
    {
        if(isFirstRight == true)
        {
            anim.SetInteger("rightMovement", 2);
            anim.SetInteger("leftMovement", 0);
            anim.SetBool("wrongPressed", false);
            isFirstRight = false;
            isLeftMovement = true;
        }
        //else
        //{
        //    anim.SetBool("wrongPressed", true);
        //    anim.SetInteger("rightMovement", 0);
        //    anim.SetInteger("leftMovement", 0);
        //    isFirstRight = false;
        //    isRightMovement = true;
        //}
    }
}
