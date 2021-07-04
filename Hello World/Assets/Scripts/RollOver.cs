using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;

    public bool firstPress = false;
    private bool secondPress = false;
    private bool thirdPress = false;
    private bool fourthPress = false;
    public bool startMovement = false;
    public bool finalPress = false;

    public GameObject winText;
    public StaminaSlider movementCheck;

    private char lastPressed;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
        lastPressed = 'A';
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
        if(lastPressed == 'A')
        {
            anim.SetBool("firstPress", true);
            anim.SetBool("tiredStart", false);
            firstPress = true;
            movementCheck.countdownBar.value = movementCheck.countdownBar.maxValue;
            lastPressed = 'B';
        }
    }

    void SecondSwing()
    {
        if(firstPress == true && lastPressed == 'B')
        {
            anim.SetBool("firstPress", false);
            anim.SetBool("secondPress", true);
            anim.SetBool("tiredStart", false);
            secondPress = true;
            movementCheck.countdownBar.value = movementCheck.countdownBar.maxValue;
            lastPressed = 'C';
        }
    }

    void ThirdSwing()
    {
        if (secondPress == true && lastPressed == 'C')
        {
            anim.SetBool("secondPress", false);
            anim.SetBool("thirdPress", true);
            anim.SetBool("tiredStart", false);
            thirdPress = true;
            movementCheck.countdownBar.value = movementCheck.countdownBar.maxValue;
            lastPressed = 'D';
        }
    }

    void FourthSwing()
    {
        if (thirdPress == true && lastPressed == 'D')
        {
            anim.SetBool("thirdPress", false);
            anim.SetBool("fourthPress", true);
            anim.SetBool("tiredStart", false);
            fourthPress = true;
            movementCheck.countdownBar.value = movementCheck.countdownBar.maxValue;
            lastPressed = 'E';
        }
    }

    void FullRoll()
    {
        if (fourthPress == true && lastPressed == 'E')
        {
            anim.SetBool("fourthPress", false);
            anim.SetBool("finalPress", true);
            anim.SetBool("tiredStart", false);
            finalPress = true;
            movementCheck.countdownBar.value = movementCheck.countdownBar.maxValue;
            winText.SetActive(true);
            lastPressed = 'F';
        }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
