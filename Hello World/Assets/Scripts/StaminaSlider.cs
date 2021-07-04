using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public RollOver movementCheck;
    public float countDownTime = 60;

    public Slider countdownBar;
    //public GameObject loseText;
    private Animator anim;
    public GameObject baby;

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void Start()
    {
        countdownBar.value = countdownBar.maxValue;
    }

    private void Update()
    {
        if (movementCheck.finalPress == false && movementCheck.firstPress == true)
        {
            countdownBar.value -= Time.deltaTime;
            

            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                movementCheck.startMovement = true;
                anim.SetBool("tiredStart", true);
                anim.SetBool("firstPress", false);
                anim.SetBool("secondPress", false);
                anim.SetBool("thirdPress", false);
                anim.SetBool("fourthPress", false);
                //loseText.SetActive(true);
            }
            else
            {
                countDown = true;
                allowInputs = true;
                movementCheck.startMovement = false;
                anim.SetBool("tiredStart", false);
            }
        }
    }
}
