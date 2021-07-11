using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public float countDownTime = 60;

    public Slider countdownBar;
    //public GameObject loseText;
    public RollOver timerCheck;
    private Animator anim;
    public GameObject baby;

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void Start()
    {
        //Set the max value to the refill time
        countdownBar.value = countdownBar.maxValue;
    }

    private void Update()
    {
        if (timerCheck.isLegUp == false)
        {
            if (countDown == true)
            {
                countdownBar.value -= Time.deltaTime;
            }

            //If we are at 0, start to refill
            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                anim.SetBool("timeOut", true);
                //loseText.SetActive(true);
            }
            else
            {
                countDown = true;
                allowInputs = true;
            }
        }
    }
}
