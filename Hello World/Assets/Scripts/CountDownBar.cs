﻿using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public float countDownTime = 60;

    public Slider countdownBar;
    public GameObject loseText;
    public WinWithToy winWithToy;
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
        if (winWithToy.gameWon == false)
        {
            if (countDown)
            {
                countdownBar.value -= Time.deltaTime;
            }

            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                anim.SetBool("timeOut", true);
                loseText.SetActive(true);
            }
            else
            {
                countDown = true;
                allowInputs = true;
            }
        }
    }
}
