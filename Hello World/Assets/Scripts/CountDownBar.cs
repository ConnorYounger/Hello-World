using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
        //Set the max value to the refill time
        countdownBar.value = countdownBar.maxValue;
    }

    private void Update()
    {
        Timer();
    }
    private IEnumerator LoseCondition()
    {
        countDown = false;
        allowInputs = false;
        anim.SetBool("timeOut", true);
        loseText.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        baby.GetComponent<AudioSource>().Play();

    }

    private void Timer()
    {
        if (winWithToy.gameWon == false && countDown)
        {
            if (countDown) //Scale the countdown time to go faster than the refill time
                countdownBar.value -= Time.deltaTime;
            if (countdownBar.value <= 0)
            {
                StartCoroutine(LoseCondition());

            }
            else
            {
                countDown = true;
                allowInputs = true;
            }

        }
    }



}
