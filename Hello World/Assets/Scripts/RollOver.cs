using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;

    private int leftSwingAmount = 0;
    private int rightSwingAmount = 0;

    private bool leftMovement = true;
    private bool rightMovement = false;
    public bool isLegUp = false;

    public float failTimer = 0;
    public float timeLimit = 0;

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
        controls.RollOver.LegMovement.performed += ctx => LegUp();
        controls.RollOver.LegMovement.canceled += ctx => LegDown();
    }

    public void Update()
    {
        if (isLegUp == true)
        {
            failTimer += Time.deltaTime;
        }

        if (failTimer >= timeLimit)
        {
            anim.SetBool("legUp", false);
            anim.SetInteger("leftSwing", 0);
            anim.SetInteger("rightSwing", 0);
            failTimer = 0;
            isLegUp = false;
        }
    }

    void LegDown()
    {
        anim.SetBool("legUp", false);
        anim.SetInteger("leftSwing", 0);
        anim.SetInteger("rightSwing", 0);
        isLegUp = false;
    }

    void LegUp()
    {
        anim.SetBool("legUp", true);
        isLegUp = true;
    }

    void SwingLeft()
    {
        if (leftMovement == true)
        {
            leftSwingAmount++;
            anim.SetInteger("leftSwing", leftSwingAmount);
            leftMovement = false;
            rightMovement = true;
            failTimer = 0;
        }
    }

    void SwingRight()
    {
        if (rightMovement == true)
        {
            rightSwingAmount++;
            anim.SetInteger("rightSwing", rightSwingAmount);
            rightMovement = false;
            leftMovement = true;
            failTimer = 0;
        }
    }
}
