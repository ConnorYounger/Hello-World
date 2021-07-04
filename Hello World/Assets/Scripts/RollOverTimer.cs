using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollOverTimer : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public float countDownTime = 60;

    public Slider countdownBar;
    public GameObject loseText;
    public bool rollWin = false;

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
        if (rollWin == false)
        {
            if (countDown)
            {
                countdownBar.value -= Time.deltaTime;
            }

            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                anim.SetBool("loseTime", true);
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
