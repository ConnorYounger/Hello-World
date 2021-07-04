using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public RollOver finalPress;
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
        if (finalPress == false)
        {
            if (countDown == true)
            {
                countdownBar.value -= Time.deltaTime;
            }

            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                //anim.SetBool("timeOut", true);
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
