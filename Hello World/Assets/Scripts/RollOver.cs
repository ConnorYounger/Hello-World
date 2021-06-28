using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;

    private bool firstPress = false;
    private bool secondPress = false;
    private bool thirdPress = false;
    private bool fourthPress = false;
    private bool finalPress = false;

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
        controls.RollOver.Key1.performed += ctx => FirstSwing();
        controls.RollOver.Key2.performed += ctx => SecondSwing();
        controls.RollOver.Key3.performed += ctx => ThirdSwing();
        controls.RollOver.Key4.performed += ctx => FourthSwing();
        controls.RollOver.Key5.performed += ctx => FullRoll();
    }

    void FirstSwing()
    {
        anim.SetBool("firstPress", true);
        firstPress = true;
    }

    void SecondSwing()
    {
        if(firstPress == true)
        {
            anim.SetBool("firstPress", false);
            anim.SetBool("secondPress", true);
            secondPress = true;
        }
    }

    void ThirdSwing()
    {
        if (secondPress == true)
        {
            anim.SetBool("secondPress", false);
            anim.SetBool("thirdPress", true);
            thirdPress = true;
        }
    }

    void FourthSwing()
    {
        if (thirdPress == true)
        {
            anim.SetBool("thirdPress", false);
            anim.SetBool("fourthPress", true);
            fourthPress = true;
        }
    }

    void FullRoll()
    {
        if (fourthPress == true)
        {
            anim.SetBool("fourthPress", false);
            anim.SetBool("finalPress", true);
            finalPress = true;
        }
    }

    void Update()
    {
        
    }
}
