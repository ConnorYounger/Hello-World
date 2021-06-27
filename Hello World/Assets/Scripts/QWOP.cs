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
        controls.QWOP.Click1.performed += ctx => LeftMovement();
        controls.QWOP.Click2.performed += ctx => RightMovement();
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
            anim.SetBool("rightPressed", false);
            anim.SetBool("leftPressed", false);
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
            anim.SetBool("leftPressed", false);
        }
    }
}
