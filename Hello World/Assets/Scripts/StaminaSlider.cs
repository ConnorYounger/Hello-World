using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public bool gameStarted = false;
    public float countDownTime = 60;

    public Slider countdownBar;
    private Animator anim;
    public GameObject baby;
    public GameObject loseText;
    public float pauseTimer = 0;

    public GameObject liftButton;
    public GameObject swingButton;
    public GameObject parentText;

    public RollOver timerCheck;
    public GameObject activate;

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void Start()
    {
        //Set the max value to the refill time
        countdownBar.value = countdownBar.maxValue;
    }

    public void StartExercise()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if(gameStarted == true)
        {
            if (countDown == true)
            {
                countdownBar.value -= Time.deltaTime;
            }

            //If we are at 0, start to refill
            if (countdownBar.value <= 0)
            {
                if (countDown == true)
                {
                    timerCheck.soundEffectsManager.PlayLoseSound();
                    timerCheck.soundEffectsManager.PlayBabyCrySound();
                }

                countDown = false;
                allowInputs = false;
                anim.SetBool("timeOut", true);
                liftButton.SetActive(false);
                swingButton.SetActive(false);
                loseText.SetActive(true);
                timerCheck.parent.PlayLoseNarrative();
                pauseTimer += Time.deltaTime;

                if (pauseTimer >= 5)
                {
                    activate.SetActive(true);
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
