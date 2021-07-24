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
    private Animator anim;
    public GameObject baby;
    public GameObject loseText;
    public float pauseTimer = 0;

    public RollOver timerCheck;
    public PauseMenuController activate;
    
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
        if (timerCheck.isLegUp == true)
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
                Destroy(timerCheck.liftButton);
                Destroy(timerCheck.swingButton);
                Destroy(timerCheck.parentText);
                Destroy(timerCheck.winText);
                loseText.SetActive(true);
                timerCheck.parent.PlayLoseNarrative();

                pauseTimer += Time.deltaTime;

                if (pauseTimer >= 5)
                {
                    activate.PauseGame();
                }
            }
            else
            {
                countDown = true;
                allowInputs = true;
            }
        }
    }
}
