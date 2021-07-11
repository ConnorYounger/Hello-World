using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;

    private bool start = true;
    private bool firstPress = false;
    private bool secondPress = false;
    private bool thirdPress = false;
    private bool fourthPress = false;
    public bool finalPress = false;

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
        controls.RollOver.Key1.performed += ctx => SwingLeft();
        controls.RollOver.Key2.performed += ctx => SwingRight();
    }

    void SwingLeft()
    {
        if (start == true)
        {
            anim.SetBool("firstPress", true);
            start = false;
            firstPress = true;
        }

        if (secondPress == true)
        {
            anim.SetBool("secondPress", false);
            anim.SetBool("thirdPress", true);
            secondPress = false;
            thirdPress = true;
        }

        if (fourthPress == true)
        {
            anim.SetBool("fourthPress", false);
            anim.SetBool("finalPress", true);
            fourthPress = false;
            finalPress = true;
        }
    }

    void SwingRight()
    {
        if(firstPress == true)
        {
            anim.SetBool("firstPress", false);
            anim.SetBool("secondPress", true);
            firstPress = false;
            secondPress = true;
        }

        if (thirdPress == true)
        {
            anim.SetBool("thirdPress", false);
            anim.SetBool("fourthPress", true);
            thirdPress = false;
            fourthPress = true;
        }
    }
}
