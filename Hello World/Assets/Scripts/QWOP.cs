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
            anim.SetBool("leftPressed", true);
            anim.SetBool("rightPressed", false);
            anim.SetBool("wrongPressed", false);
            isLeftMovement = false;
            isRightMovement = true;
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetBool("leftPressed", false);
            anim.SetBool("leftPressed1", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("rightPressed1", false);
        }
    }

    void LeftMovement1()
    {
        if (isLeftMovement == true)
        {
            anim.SetBool("leftPressed1", true);
            anim.SetBool("rightPressed1", false);
            anim.SetBool("wrongPressed", false);
            isLeftMovement = false;
            isRightMovement = true;
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetBool("leftPressed", false);
            anim.SetBool("leftPressed1", false);
            anim.SetBool("rightPressed", false);
            anim.SetBool("rightPressed1", false);
        }
    }

    void RightMovement()
    {
        if (isRightMovement == true)
        {
            anim.SetBool("rightPressed", true);
            anim.SetBool("leftPressed", false);
            anim.SetBool("wrongPressed", false);
            isRightMovement = false;
            isLeftMovement = true;
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetBool("rightPressed", false);
            anim.SetBool("rightPressed1", false);
            anim.SetBool("leftPressed", false);
            anim.SetBool("leftPressed1", false);
        }
    }

    void RightMovement1()
    {
        if (isRightMovement == true)
        {
            anim.SetBool("rightPressed1", true);
            anim.SetBool("leftPressed1", false);
            anim.SetBool("wrongPressed", false);
            isRightMovement = false;
            isLeftMovement = true;
        }
        else
        {
            anim.SetBool("wrongPressed", true);
            anim.SetBool("rightPressed", false);
            anim.SetBool("rightPressed1", false);
            anim.SetBool("leftPressed", false);
            anim.SetBool("leftPressed1", false);
        }
    }
}
